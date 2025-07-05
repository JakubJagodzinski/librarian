using System.Collections;
using System.ComponentModel;

public class SortableBindingList<T> : BindingList<T>
{
    private bool _isSorted;
    private ListSortDirection _sortDirection;
    private PropertyDescriptor _sortProperty;

    public SortableBindingList() : base() { }
    public SortableBindingList(IList<T> list) : base(list) { }

    protected override bool SupportsSortingCore => true;
    protected override bool IsSortedCore => _isSorted;
    protected override ListSortDirection SortDirectionCore => _sortDirection;
    protected override PropertyDescriptor SortPropertyCore => _sortProperty;

    protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    {
        var items = Items as List<T>;
        if (items != null)
        {
            var pc = TypeDescriptor.GetProperties(typeof(T));
            var property = pc[prop.Name];

            var listToSort = items.ToList();
            listToSort.Sort((x, y) =>
            {
                var xValue = property.GetValue(x);
                var yValue = property.GetValue(y);

                if (xValue == null && yValue == null) return 0;
                if (xValue == null) return -1;
                if (yValue == null) return 1;

                var result = Comparer.Default.Compare(xValue, yValue);
                return direction == ListSortDirection.Ascending ? result : -result;
            });

            Items.Clear();
            foreach (var item in listToSort)
            {
                Items.Add(item);
            }

            _isSorted = true;
            _sortDirection = direction;
            _sortProperty = prop;
        }
    }

    protected override void RemoveSortCore()
    {
        _isSorted = false;
        _sortProperty = null;
    }
}