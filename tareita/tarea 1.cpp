#include <iostream>
 using namespace std;
 int main(){
int NumeroInicial = 0;
int NumeroFinal = 0;
 cout<<"introduzca un valor inicial"<<endl;
 cin>> NumeroInicial;
 cout<<"introduzca un valor final"<<endl;
 cin>>NumeroFinal;
 if (NumeroInicial>=NumeroFinal){
    cout<<"el numero inicial debe ser menor que el numero final";
 }
 for(int i = NumeroInicial; i <= NumeroFinal; i++){
 if (i % 2 !=0){
    cout<<i<<endl;
 }
 }
 return 0;
 }
