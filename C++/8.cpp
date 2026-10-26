#include<iostream>
using namespace std;
int main(){
    cout<<"Enter number :"<<endl;
    int num;
    cin>>num;
    if(num>0){
        cout<<"This is positive number "<<endl;
        }
    else if(num==0){
        cout<<"This is zero"<<endl;
    }
    else{
        cout<<"This is negative number "<<endl;
    }
    return 0;
}