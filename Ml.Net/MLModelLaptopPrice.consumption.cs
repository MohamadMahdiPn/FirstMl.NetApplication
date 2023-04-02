﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace Ml_Net
{
    public partial class MLModelLaptopPrice
    {
        /// <summary>
        /// model input class for MLModelLaptopPrice.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"CPU")]
            public string CPU { get; set; }

            [ColumnName(@"GHz")]
            public float GHz { get; set; }

            [ColumnName(@"GPU")]
            public string GPU { get; set; }

            [ColumnName(@"RAM")]
            public float RAM { get; set; }

            [ColumnName(@"RAMType")]
            public string RAMType { get; set; }

            [ColumnName(@"Screen")]
            public float Screen { get; set; }

            [ColumnName(@"Storage")]
            public float Storage { get; set; }

            [ColumnName(@"SSD")]
            public bool SSD { get; set; }

            [ColumnName(@"Weight")]
            public float Weight { get; set; }

            [ColumnName(@"Price")]
            public float Price { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for MLModelLaptopPrice.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"CPU")]
            public float[] CPU { get; set; }

            [ColumnName(@"GHz")]
            public float GHz { get; set; }

            [ColumnName(@"GPU")]
            public float[] GPU { get; set; }

            [ColumnName(@"RAM")]
            public float RAM { get; set; }

            [ColumnName(@"RAMType")]
            public float[] RAMType { get; set; }

            [ColumnName(@"Screen")]
            public float Screen { get; set; }

            [ColumnName(@"Storage")]
            public float Storage { get; set; }

            [ColumnName(@"SSD")]
            public float[] SSD { get; set; }

            [ColumnName(@"Weight")]
            public float Weight { get; set; }

            [ColumnName(@"Price")]
            public float Price { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("MLModelLaptopPrice.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}
