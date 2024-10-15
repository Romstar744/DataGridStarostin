using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridStarostin
{
    /// <summary>
    /// Расширения для различных классов
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Создание связки двух полей
        /// </summary>
        public static void AddBinding<TControl, TSource>(this TControl target,
            Expression<Func<TControl, object>> targetProperty,
            TSource source,
            Expression<Func<TSource, object>> sourceProperty,
            ErrorProvider errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            var targetName = GetMemberName(targetProperty);
            var sourceName = GetMemberName(sourceProperty);
            target.DataBindings.Add(new Binding(targetName, source, sourceName,
                false,
                DataSourceUpdateMode.OnPropertyChanged));
            if (errorProvider != null)
            {
                var sourcePropertyInfo = source.GetType().GetProperty(sourceName);
                var validators = sourcePropertyInfo.GetCustomAttributes<ValidationAttribute>();
                if (validators?.Any() == true)
                {
                    target.Validating += (sender, args) =>
                    {
                        var context = new ValidationContext(source);
                        var results = new List<ValidationResult>();
                        errorProvider.SetError(target, string.Empty);
                        if (!Validator.TryValidateObject(source, context, results, validateAllProperties: true))
                        {
                            foreach (var error in results.Where(x => x.MemberNames.Contains(sourceName)))
                            {
                                errorProvider.SetError(target, error.ErrorMessage);
                            }
                        }
                    };
                }
            }
        }

        /// <summary>
        /// Получить имя нужного поля
        /// </summary>
        private static string GetMemberName<TItem, TMember>(Expression<Func<TItem, TMember>> targetMemeber)
        {
            if (targetMemeber.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            if (targetMemeber.Body is UnaryExpression unaryExpression)
            {
                var operand = unaryExpression.Operand as MemberExpression;
                return operand.Member.Name;
            }

            throw new ArgumentException();
        }
    }
}
