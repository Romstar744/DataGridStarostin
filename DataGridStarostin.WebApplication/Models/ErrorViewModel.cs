namespace DataGridStarostin.WebApplication.Models
{
    /// <summary>
    /// ������ ��� ����������� ���������� �� ������ ������������. �������� ������������� ������� � ������ ��������, �����������, ������� �� ���������� ������������� �������.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// ������������� �������, ���������� ������. ����� ���� null.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// ���������, ������� �� ���������� RequestId. True, ���� RequestId �� null � �� ����; �����, false.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
