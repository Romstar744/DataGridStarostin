namespace DataGridStarostin.WebApplication.Models
{
    /// <summary>
    /// Модель для отображения информации об ошибке пользователю. Содержит идентификатор запроса и булево значение, указывающее, следует ли отображать идентификатор запроса.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Идентификатор запроса, вызвавшего ошибку. Может быть null.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Указывает, следует ли отображать RequestId. True, если RequestId не null и не пуст; иначе, false.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
