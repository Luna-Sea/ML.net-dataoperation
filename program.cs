using static System.Console;
using System.IO;
using Microsoft.ML.Data;
using Microsoft.ML;
using System.Data;

public class Input
    {
    [LoadColumn(0)] public string? Sex { get; set; }
    [LoadColumn(1)] public float Length { get; set; }
    [LoadColumn(2)] public float Diameter { get; set; }
    [LoadColumn(3)] public float Height { get; set; }
    [LoadColumn(4)] public float Whole { get; set; }
    [LoadColumn(5)] public float Shucked { get; set; }
    [LoadColumn(6)] public float Viscera { get; set; }
    [LoadColumn(7)] public float Shell { get; set; }
    [LoadColumn(8)] public float Rings { get; set; }
    [LoadColumn(9)] public float testvalues { get; set; }
    }
class Output
    {
     public string? Sex { get; set; }
     public float Length { get; set; }
     public float Diameter { get; set; }
     public float Height { get; set; }
     public float Whole { get; set; }
     public float Shucked { get; set; }
     public float Viscera { get; set; }
     public float Shell { get; set; }
     public float Rings { get; set; }
     public float testvalues { get; set; }
    }

class Program
    {

    static void Main(string[] args)
        {
        MLContext context = new();//创建环境
        string datapath = @"G:\VSstudio2022项目\C#项目\ML.net-DataOperation\ML.net-DataOperation\abalone.txt";
        IDataView dataview = context.Data.LoadFromTextFile<Input>(datapath, separatorChar: ',',hasHeader:true);

        //var pipeline = context.Transforms.CustomMapping<Input, Output>(
        //    (input, output) =>
        //    {
        //        float values = jisuan();//每行都会执行
        //        output.testvalues = values;
        //    }
        //    , "testvalues");

        int num = 100;
        Output[] outputs = new Output[num];
        for (int i = 0; i < num; i++)
            {
            outputs[i] = new Output();
            }

        var Length = dataview.GetColumn<float>("Length");
        var Diameter = dataview.GetColumn<float>("Diameter");
        var Height = dataview.GetColumn<float>("Height");
        var Whole = dataview.GetColumn<float>("Whole");

        float[] Length_new = dataview.GetColumn<float>("Length").ToArray();



        string path_2 = @"G:\VSstudio2022项目\C#项目\ML.net-DataOperation\ML.net-DataOperation\123.txt";
        using  StreamWriter writer = new StreamWriter(path_2);
        for(int i = 0; i < num; i++)
            {
            outputs[i].Length = Length_new[i];
            writer.WriteLine(outputs[i].Length);
            WriteLine(outputs[i].Length);
            }




        //IDataView newdataview = context.Data.LoadFromEnumerable<Output>(outputs);
        //var preview = newdataview.Preview(maxRows:10);
        //foreach(var row in preview.RowView)
        //    {
        //        foreach(var col in row.Values)
        //        {
        //        Write(col.Value);
        //        }
        //    WriteLine();
        //    }



        }
    }
