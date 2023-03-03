using System;

namespace Platform.LinearAlgebra
{

    public class LDU : LU {
        public Matrix D;
        public LDU(Matrix matrix) : base(matrix) { }

        public override void Decompose(){
            base.Decompose();
            D = new Matrix(U.Rows(), U.Columns());
            Divide();
            L.Print();
            D.Print();
            U.Print();
        }

        public void Divide(){
            int diagonalLength = Math.Min(U.Rows(), U.Columns());
            for(int diagPosition = 0; diagPosition < diagonalLength; diagPosition++){
                D.At(diagPosition, diagPosition, U.At(diagPosition, diagPosition));
                for(int rowPosition = diagPosition; rowPosition >= 0; rowPosition--){
                    U.At(rowPosition, diagPosition,U.At(rowPosition, diagPosition) / D.At(rowPosition, diagPosition));
                }
            }
            
            
        }
    }

}