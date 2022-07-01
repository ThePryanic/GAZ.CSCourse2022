using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeasuringDevice
{
    // TODO: Implement the IMeasuringDevice interface.
    public interface IMeasuringDevice
    {
         /// <summary>
        /// Converts the raw data collected by the measuring device into a metric value.
        /// </summary>
        /// <returns>The latest measurement from the device converted to metric units.</returns>
        // Преобразует необработанные данные, собранные измерительным устройством, в метрическое значение
        // Последнее измерение с устройства, преобразованное в метрические единицы.
         decimal MetricValue();

         /// <summary>
         /// Converts the raw data collected by the measuring device into an imperial value.
         /// </summary>
         /// <returns>The latest measurement from the device converted to imperial units.</returns>
         // Преобразует необработанные данные, собранные измерительным устройством, в имперское значение.
         // Последнее измерение с устройства, преобразованное в имперские единицы.
         decimal ImperialValue();

         /// <summary>
         /// Starts the measuring device.
         /// </summary>
         // Запускает измерительное устройство.
         void StartCollecting();

         /// <summary>
         /// Stops the measuring device. 
         /// </summary>
         // Останавливает измерительное устройство.
         void StopCollecting();

         /// <summary>
         /// Enables access to the raw data from the device in whatever units are native to the device.
         /// </summary>
         /// <returns>The raw data from the device in native format.</returns>
         //Позволяет получить доступ к необработанным данным с устройства в любых единицах измерения, которые являются родными для устройства.
         // Исходные данные с устройства в собственном формате
         int[] GetRawData();
    }
}
