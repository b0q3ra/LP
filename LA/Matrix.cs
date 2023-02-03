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



        //ARITHMETIC
        public void Add(Matrix foreign){
            for(int row = 0; row < mstorage.GetLength(0); row++){
                for(int column = 0; column < mstorage.GetLength(0); column++){
                    mstorage[row, column] += foreign.At(row, column);
                }
            }
        }

        public void Product(Matrix foreign){
            
            //FOREIGN AND LOCAL HAVE SAME NUMBER OF COL-ROW
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