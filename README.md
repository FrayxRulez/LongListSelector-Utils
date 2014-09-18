IncremetalLoadingBehavior
-------------
 - Create a new class that inherit `ObservableCollection<T>` and `ISupportIncrementalBehavior` and set it as `ItemsSource` of your `LongListSelector`.
 - Add `IncrementalLoadingBehavior` to your `LongListSelector`.
 - Add an `Header/HeaderTemplate` to your `LongListSelector` to let the behavior initialize (It can be empty)