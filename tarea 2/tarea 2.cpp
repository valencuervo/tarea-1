#include <iostream>
using namespace std;
int main () {
int edad = 0;
int anio = 2024;
int aniosPares = 0;
int aniosImpares = 0;
 cout<<"ingresa tu edad"<<endl;
 cin>>edad;
 int anioNacimiento = anio-edad;
 for(int i = anioNacimiento; i < anio; ++i){


    cout<<i<<endl;

    if(i < anio){

    }
    if (i % 2 == 0){
        aniosPares = aniosPares + 1;
    }
    if (i % 2 != 0){
        aniosImpares = aniosImpares + 1;
    }
 }
    cout<<"los anios impares son:"<<endl; cout<< aniosImpares<<endl;
    cout<<"los anios pares son:"<<endl; cout<< aniosPares<<endl;



return 0;
}
