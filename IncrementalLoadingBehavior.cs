using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace LongListSelectorUtils
{
    public class IncrementalLoadingBehavior : Behavior<LongListSelector>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.ItemRealized += OnItemRealized;
        }

        private async void OnItemRealized(object sender, ItemRealizationEventArgs e)
        {
            var longListSelector = sender as LongListSelector;
            if (longListSelector == null)
            {
                return;
            }

            var item = e.Container.Content;
            var items = longListSelector.ItemsSource;
            var index = items.IndexOf(item);

            if ((items.Count - index <= 1) && longListSelector.ItemsSource is ISupportIncrementalLoading)
            {
				var items = longListSelector.ItemsSource as ISupportIncrementalLoading;
                if (!items.IsLoading && items.HasMoreItems)
                {
                    await items.LoadMore();
                }
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.ItemRealized -= OnItemRealized;
        }
    }
	
	public interface ISupportIncrementalLoading
    {
        Task LoadMore();

        bool IsLoading { get; }

        bool HasMoreItems { get; }
    }
}
