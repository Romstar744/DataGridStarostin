using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

namespace DataGridStarostin.WebApplication
{
    /// <summary>
    /// Вспомогательный класс для работы с перечислениями (enum), предоставляющий способ получения списка элементов SelectListItem из типа перечисления.  Полезно для заполнения выпадающих списков в представлениях Razor.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Создает список элементов SelectListItem из типа перечисления, используя атрибут DescriptionAttribute, если он доступен, в противном случае используя имя значения перечисления.
        /// </summary>
        public static IEnumerable<SelectListItem> GetEnumDescriptions(Type enumType)
        {
            var selectListItems = new List<SelectListItem>();

            foreach (Enum value in Enum.GetValues(enumType))
            {
                var descriptionText = value.GetType()
                                           .GetField(value.ToString())?
                                           .GetCustomAttribute<DescriptionAttribute>()?.Description
                                           ?? value.ToString();

                string valueString = Convert.ToString(Convert.ChangeType(value, enumType.GetEnumUnderlyingType()));


                selectListItems.Add(new SelectListItem { Text = descriptionText, Value = valueString });
            }

            return selectListItems;
        }
    }
}
