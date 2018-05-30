namespace Presentation.Converters
{
    using System.Windows;

    class ExistenceToVisibility : ValueConverter<object, Visibility>
    {
        protected override Visibility Convert(object value)
        {
            return value == null ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
