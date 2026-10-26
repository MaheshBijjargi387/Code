//Even or Odd number
#include<iostream>
using namespace std;
void evenOdd(int num){
    if(num%2==0){
        cout<<"This is even number";
    }
    else{
        cout<<"Odd number";
    }
}

int main(){
    cout<<"Enter number :";
    int num;
    cin>>num;
    evenOdd(num);
    
}