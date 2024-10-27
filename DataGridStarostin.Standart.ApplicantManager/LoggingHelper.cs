using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace DataGridStarostin.Standart.ApplicantManager
{
    static internal class LoggingHelper
    {
        private const string InfoLoggerTemplateApplicant =
           "Заполнено {0} для абитуриента с идентификатором {1} и именем \"{2}\", прошло время: {3} мс; дата: {4}";
        private const string ErrorLoggerTemplateApplicant =
            "Не удалось заполнить {0} для абитуриента с идентификатором {1} и именем \"{2}\", прошло время: {3} мс; дата: {4}; сообщение об ошибке: {5}";
        private const string ErrorLoggerTemplateCommon =
            "Не удалось завершить {0}, дата: {1}; сообщение об ошибке: {2}";

        /// <summary>
        /// Залогировать информацию о действии с абитуриентом
        /// </summary>
        public static void LogErrorApplicant(ILogger logger, string actionName, Guid applicantId, long msElapsed, string errorMessage, string applicantName = null)
        {
            logger.LogError(
                string.Format(
                ErrorLoggerTemplateApplicant,
                actionName,
                applicantId,
                applicantName ?? "-",
                msElapsed,
                DateTime.Now,
                errorMessage
                )
                );
        }

        /// <summary>
        /// Логирование ошибки при действии с абитуриентом
        /// </summary>
        public static void LogInfoApplicant(ILogger logger, string actionName, Guid applicantId, long msElapsed, string applicantName = null)
        {
            logger.LogInformation(
                string.Format(
                InfoLoggerTemplateApplicant,
                actionName,
                applicantId,
                applicantName ?? "-",
                msElapsed,
                DateTime.Now
                )
                );
        }

        /// <summary>
        /// Логирование ошибки
        /// </summary>
        public static void LogError(ILogger logger, string actionName, string errorMessage)
        {
            logger.LogError(string.Format(
            ErrorLoggerTemplateCommon,
            actionName,
            DateTime.Now,
            errorMessage
            )
            );
        }
    }
}
