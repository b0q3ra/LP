using System;

namespace Platform.LinearAlgebra
{

    public class LU
    {
        public Matrix L;
        public Matrix U;
        public Matrix matrix;
        

        //CONSTRUCTOR
        public LU(Matrix matrix)
        {

            this.matrix = (Matrix) matrix.ShallowCopy();

            (int rows, int columns) = this.matrix.Dim();
            this.L = new Matrix(rows, columns);
            this.U = new Matrix(rows, columns);


            U.Identity();
            L.Identity();
        }


        //DECOMPOSEtest
        public virtual void Decompose()
        {
            Matrix elementary = new Matrix(matrix.Rows(), matrix.Columns());
            
            //SET L = MATRIX, U = Id
            U = (Matrix) matrix.ShallowCopy();
            L.Identity();
            
            int diagonalLength = Math.Min(U.Rows(), U.Columns());
            for (int pivotPosition = 0; pivotPosition < diagonalLength; pivotPosition++)
            {

                

                //FIND NEXT ROW WITH VALID PIVOT AND INTERCHANGE IT, IF NO NON-ZERO PIVOT EXISTS, RETURN
                int nextPivotRow = FindRowPivot(U, pivotPosition);
                if(nextPivotRow == -1) return;
                if(nextPivotRow != pivotPosition){
                    elementary.Identity();
                    Interchange(U, pivotPosition, nextPivotRow);
                    Interchange(elementary, pivotPosition, nextPivotRow);
                    L.Product(elementary);
                } 
                
                //ELIMINATE COLUMN UNDER PIVOT
                for(int currentRow = pivotPosition + 1; currentRow < U.Rows(); currentRow++){
                    elementary.Identity();
                    double coefficient =  U.At(currentRow, pivotPosition) / U.At(pivotPosition, pivotPosition);
                    AddScaled(U, pivotPosition, currentRow, (-1) * coefficient);
                    AddScaled(elementary, pivotPosition, currentRow, (1) * coefficient);
                    L.Product(elementary);
                    
                }

            }

            
        }

        //SETTER GETTER
        public Matrix getUpper(){
            return U;
        }

        public Matrix getLower(){
            return L;
        }


        //ROW OPERATIONS
        public void Interchange(Matrix m, int rowA, int rowB)
        {
            //INTERCHANGE ROWS
            for (int column = 0; column < m.Columns(); column++)
            {
                double temp = m.At(rowA, column);
                m.At(rowA, column, m.At(rowB, column));
                m.At(rowB, column, temp);
            }
        }

        public void Scale(Matrix m, int row, double scalar)
        {
            //SCALE ROW
            for (int column = 0; column < matrix.Columns(); column++)
            {
                m.At(row, column, scalar * m.At(row, column));
            }
        }

        public void AddScaled(Matrix m, int baseRow, int targetRow, double scalar)
        {
            //ADD SCALED ROW
            for (int column = 0; column < m.Columns(); column++)
            {
                double temp = m.At(targetRow, column) + scalar * m.At(baseRow, column);
                m.At(targetRow, column, temp);
            }
        }

        public int FindRowPivot(Matrix m, int pivotPosition)
        {
            
            //GET PIVOT VALUE AT M[PIVOTPOSITION, PIVOTPOSITION]
            double pivot = m.At(pivotPosition, pivotPosition);

            //SET INITIAL VALUE AS TO PIVOT POSITION
            int nextRowWithPivot = pivotPosition;

            //WHILE PIVOT == 0, SEARCH FOR NON-ZERO PIVOT
            while (pivot == 0)
            {
                
                //PIVOT IS 0, SO INCREMENT POINTER TO NEXT ROW (EXCEPT IF LAST ROW IS HITTED, THEN RETURN -1)
                if(nextRowWithPivot < m.Rows() - 1) nextRowWithPivot++;
                else return nextRowWithPivot = -1;

                //CHECK IF PIVOT IS NON ZERO, IF IT IS, REPEAT, ELSE EXIT LOOP
                pivot = m.At(nextRowWithPivot, pivotPosition);
                
            } 
            
            //RETURN POSITION
            return nextRowWithPivot;
        }
    }
}