using System;

namespace Platform.LinearAlgebra{
    
    public class LU {
        Matrix L;
        Matrix U;
        Matrix matrix;

        //CONSTRUCTOR
        public LU(Matrix matrix){
            
            this.matrix = matrix;

            (int rows, int columns) = matrix.Dim();
            this.L = new Matrix(rows, columns);
            this.U = new Matrix(rows, columns);
        }

        //OPERATION
        public Matrix rowOperation(double coefficient, int baseRow, int targetRow){
            
            
            return U;
        }
        
    }
}