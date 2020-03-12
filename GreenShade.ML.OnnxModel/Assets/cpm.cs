// This file was automatically generated by VS extension Windows Machine Learning Code Generator v3
// from model file cpm.onnx
// Warning: This file may get overwritten if you add add an onnx file with the same name
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Media;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.AI.MachineLearning;
namespace GreenShade.ML.OnnxModel
{
    
    public sealed class cpmInput
    {
        public TensorFloat input_placeholer00; // shape(-1,256,256,3)
    }
    
    public sealed class cpmOutput
    {
        public TensorFloat stage_30mid_conv70BiasAdd00; // shape(-1,32,32,22)
    }
    
    public sealed class cpmModel
    {
        private LearningModel model;
        private LearningModelSession session;
        private LearningModelBinding binding;
        public static async Task<cpmModel> CreateFromStreamAsync(IRandomAccessStreamReference stream)
        {
            cpmModel learningModel = new cpmModel();
            learningModel.model = await LearningModel.LoadFromStreamAsync(stream);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);
            return learningModel;
        }
        public async Task<cpmOutput> EvaluateAsync(cpmInput input)
        {
            binding.Bind("input_placeholer:0", input.input_placeholer00);
            var result = await session.EvaluateAsync(binding, "0");
            var output = new cpmOutput();
            output.stage_30mid_conv70BiasAdd00 = result.Outputs["stage_3/mid_conv7/BiasAdd:0"] as TensorFloat;
            return output;
        }
    }
}
