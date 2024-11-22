namespace DataGridStarostin.Standart.Contracts.Models
{

    /// <summary>
    /// Интерфейс для вычисляемых данных о списке <see cref="Applicant"/>
    /// </summary>
    public interface IApplicantStats
    {

        /// <summary>
        /// Общее количество абитуриентов
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Общее количество абитуриентов представителей женского пола
        /// </summary>
        int FemaleCount { get; }

        /// <summary>
        /// Общее количество абитуриентов представителей мужского пола
        /// </summary>
        int MaleCount { get; }

        /// <summary>
        /// Общее количество абитуриентов на очном обучении
        /// </summary>
        int FullTimeCount { get; }

        /// <summary>
        /// Общее количество абитуриентов на очно-заочном обучении
        /// </summary>
        int FTPTCount { get; }

        /// <summary>
        /// Общее количество абитуриентов на заочном обучении
        /// </summary>
        double СorrespondenceCount { get; }

        /// <summary>
        /// Количество баллов по математике у абитуриентов
        /// </summary>
        double MathCount { get; }

        /// <summary>
        /// Количество баллов по русскому языку у абитуриентов
        /// </summary>
        double RussianCount { get; }

        /// <summary>
        /// Количество баллов по информатике у абитуриентов
        /// </summary>
        double ComputerScienceCount { get; }

        /// <summary>
        /// Общее количество баллов у абитуриентов за все экзамены
        /// </summary>
        double TotalScoreCount { get; }
    }
}
