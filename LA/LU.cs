using System;

namespace Platform.LinearAlgebra
{

    public class LU
    {
        Matrix L;
        Matrix U;
        public Matrix matrix;

        //CONSTRUCTOR
        public LU(Matrix matrix)
        {

            this.matrix = matrix;

            (int rows, int columns) = matrix.Dim();
            this.L = new Matrix(rows, columns);
            this.U = new Matrix(rows, columns);


            U.Identity();
            L.Identity();
        }



        public void Simplify()
        {

            //GET DIMENSIONS
            (int rows, int columns) = matrix.Dim();
            int diagonalLength = Math.Max(rows, columns);
            
            //FIX BASE ROW, FROM WHICH WE WILL TAKE THE PIVOT
            for (int diagonal = 0; diagonal < diagonalLength; diagonal++)
            {

                double pivot = matrix.At(diagonal, diagonal);
                
                for (int row = diagonal + 1; row < rows; row++)
                {
                    
                    double underPivot = matrix.At(row, diagonal);
                    for (int col = diagonal; col < columns; col++)
                    {
                        double result = matrix.At(row, col) - matrix.At(diagonal, col) * (underPivot / pivot);
                        matrix.At(row, col, result);
                        
                    }
                    
                }

            }

        }

        //CHANGE ROWS
        public void interchange(int row1, int row2){
            for(int n = 0; n < matrix.Columns(); n++){
                
            }
        }


        public void rowOperation(int baseRow, int targetRow, double coefficient){
            for(int column = 0; column < matrix.Columns(); column++){
                double result = matrix.At(targetRow, column) + coefficient * matrix.At(baseRow, column);
                matrix.At(targetRow, column, result);
            }
        }
    
    }
}