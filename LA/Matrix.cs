using System;

namespace Platform.LinearAlgebra {

    public class Matrix {
        double[,] mstorage;
        


        //CONSTRUCTOR
        public Matrix(double[,] mstorage){
            this.mstorage = mstorage;
        }

        public Matrix(int rows = 0, int columns = 0) { 
            mstorage = new double[rows, columns];
            Identity();
        }

        public Matrix(int square){
            mstorage = new double[square, square];
            Identity();
        }



        //GENERATE IDENTITY
        public void Identity(){
            for(int row = 0; row < this.mstorage.GetLength(0); row++){
                for(int column = 0; column < this.mstorage.GetLength(1); column++){
                    if(row == column) mstorage[row, column] = 1;
                    else mstorage[row, column] = 0;
                }
            }
        }

        //GENERATE NULL
        public void Null(){
            for(int row = 0; row < this.mstorage.GetLength(0); row++){
                for(int column = 0; column < this.mstorage.GetLength(1); column++){
                    mstorage[row, column] = 0;
                }
            }
        }


        //ARITHMETIC
        public void Add(Matrix foreign){
            for(int row = 0; row < mstorage.GetLength(0); row++){
                for(int column = 0; column < mstorage.GetLength(0); column++){
                    mstorage[row, column] += foreign.At(row, column);
                }
            }
        }

        public Matrix Product(Matrix foreign, bool postproduct = true){
            
            //CHECK IF DIMENSIONS COMPATIBLE FOR PRODUCT (MxN * NXK)
            if(foreign.Rows() != this.Columns()) throw new Exception("Matrix column should havee the same dimensions");
            int intermediateColRows = this.Columns();// N

            //GENERATE NULL RESULT MATRIX
            int resultRows = this.Rows();
            int resultColumns = foreign.Columns();
            Matrix result = new Matrix(resultRows, resultColumns);
            result.Null();

            
            //CALCULATE NEW MATRIX
            double temp = 0;
            for(int row = 0; row < resultRows; row++){
                for(int column = 0; column < resultColumns; column++){
                    
                    if(postproduct)temp = ProductAt(row, column, this, foreign);//THIS * FOREIGN
                    else temp = ProductAt(row, column, foreign, this);//FOREIGN * THIS

                    result.At(row, column, temp);
                }
            }

            //RETURN RESULT
            return result;
        }

        public double ProductAt(int row, int column, Matrix A, Matrix B){
            try{

                //CHECK IF DIMENSIONS ARE VALID FOR MATRIX MULTIPLICATION (NxK * KxM)
                if(A.Columns() != B.Rows()) throw new Exception("Matrix dimensions should match");
                int intermediate = A.Columns();//intermediate = K
                
                //PERFOM CALCULATION
                double temp = 0;
                for(int n = 0; n < intermediate; n++){
                    temp += A.At(row, n) * B.At(n, column);
                }

                //RETURN VALUE
                return temp;
            }catch(Exception e){
                throw new Exception(e.Message);
            }
        }






        //SINGLE ELEMENT ACCESS
        public double At(int row, int column){
            return mstorage[row, column];
        }

        public double At(int row, int column, double value){
            return mstorage[row, column] = value;
        }



        //MASSIVE ACCESS
        public double[,] Storage(){
            return mstorage;
        }

        public double[,] Storage(double[,] mstorage){
            return this.mstorage = mstorage;
        }




        //GET DIMENSIONS
        public (int rows, int columns) Dim(){
            return (this.mstorage.GetLength(0), this.mstorage.GetLength(1));
        }
        public int Rows(){
            return mstorage.GetLength(0);
        }
        public int Columns(){
            return mstorage.GetLength(1);
        }
        
        //PRINT
        public void Print(){

            
            for(int rowpointer = 0; rowpointer < mstorage.GetLength(0); rowpointer++){
                for(int columnpointer = 0; columnpointer < mstorage.GetLength(1); columnpointer++){

                    //GET CURRENT CURSOR POSITION
                    (int x, int y) = Console.GetCursorPosition();

                    //SET CURSOR POSITION (y + 1) = next line and (1 + 10) anm an(m+10) an(m+20) etc
                    int offset = 0;
                    if(mstorage[rowpointer, columnpointer] >= 0) offset++;
                    Console.SetCursorPosition((10 * columnpointer) + offset, y);

                    
                    Console.Write(mstorage[rowpointer, columnpointer]);//WRITE
                }
                Console.WriteLine();                
                
            }
        }

    }
}