using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Platform.LinearAlgebra;

namespace Platform
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Matrix m = new Matrix(new double[,]{
            { 2, 1, 0},
            { 1, 2, 1},
            { 0, 1, 2},
           });
            
            LU machine = new LU(m);

            machine.Decompose();

            Matrix l = machine.getLower();
            l.Print();
            
        }
    }
}