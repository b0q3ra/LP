using System;

namespace Platform.LinearAlgebra {

    public class Matrix {
        double[,] mstorage;

        //CONSTRUCTOR
        public Matrix(int rows = 0, int columns = 0) { 
            mstorage = new double[rows, columns];
        }

        public Matrix(double[,] mstorage){
            this.mstorage = mstorage;
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