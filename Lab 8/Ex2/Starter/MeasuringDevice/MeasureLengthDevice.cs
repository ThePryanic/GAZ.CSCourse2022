using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeviceControl;

namespace MeasuringDevice
{
    // TODO: Implement the MeasureLengthDevice class.
    public class MeasureLengthDevice : IMeasuringDevice
    {
        public MeasureLengthDevice(Units deviceUnits)
        {
            unitsToUse = deviceUnits;
        } 

        public decimal MetricValue()
        {
            decimal metricMostRecentMeasure;
            if (unitsToUse == Units.Metric)
            {
                metricMostRecentMeasure =
                Convert.ToDecimal(mostRecentMeasure);
            }
            else
            {
                // Imperial measurements are in inches.
                //Имперские измерения указаны в дюймах.
                // Multiply imperial measurement by 25.4 to convert from inches to millimeters.
                // Умножение имперских измерений на 25,4, чтобы перевести дюймы в миллиметры. 
                // Convert from an integer value to a decimal.
                // Преобразование целочисленное значение в десятичное.
                decimal decimalImperialValue =Convert.ToDecimal(mostRecentMeasure);
                decimal conversionFactor = 25.4M;
                metricMostRecentMeasure = decimalImperialValue * conversionFactor;
            }
            return metricMostRecentMeasure;
        }

        public decimal ImperialValue()
        {
            decimal imperialMostRecentMeasure;
            if (unitsToUse == Units.Imperial)
            {
                imperialMostRecentMeasure = Convert.ToDecimal(mostRecentMeasure);
            }
            else
            {
                // Metric measurements are in millimeters.
                // Метрические измерения указаны в миллиметрах.
                // Multiply metric measurement by 0.03937 to convert from  millimeters to inches. 
                // Умножение метрических измерений на 0,03937, чтобы преобразовать миллиметры в дюймы. 
                // Convert from an integer value to a decimal.
                // Преобразование из целочисленного значения в десятичное.
                decimal decimalMetricValue =
                Convert.ToDecimal(mostRecentMeasure);
                decimal conversionFactor = 0.03937M;
                imperialMostRecentMeasure = decimalMetricValue * conversionFactor;
            }
            return imperialMostRecentMeasure;
        }

        public void StartCollecting()
        {
            controller = DeviceController.StartDevice(measurementType);
            GetMeasurements();
        }

        public void StopCollecting()
        {
            if(controller != null)
              {
                  controller.StopDevice();
                  controller = null;
              }
        }

        public int[] GetRawData()
        {
            return dataCaptured;
        }

        private Units unitsToUse;
        private int[] dataCaptured;
        private int mostRecentMeasure;
        private DeviceController controller;
        private DeviceType measurementType = DeviceType.LENGTH;

        private void GetMeasurements()
        {
            dataCaptured = new int[10];
            System.Threading.ThreadPool.QueueUserWorkItem((dummy) =>
            {
                int x = 0;
                Random timer = new Random();
                while (controller != null)
                {
                    System.Threading.Thread.Sleep(timer.Next(1000, 5000));
                    dataCaptured[x] = controller != null ?
                    controller.TakeMeasurement() : dataCaptured[x];
                    mostRecentMeasure = dataCaptured[x];
                    x++;
                    if (x == 10)
                    {
                        x = 0;
                    }
                }
            });
        } 
    } 
}
