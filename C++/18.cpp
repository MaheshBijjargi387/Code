#include<iostream>
using namespace std;

int main(){
    for(int i=1;i<=9;i++){
        int start;
        if(i<=5){
            start=i;
        }
        else{
            start=10-i;
        }
        for(int j=1;j<=9;j++){
            if(j>=6-start && j<=4+start){
                cout<<"*";
            }
            else{
                cout<<" ";
            }
        }
        cout<<endl;
    }
    return 0;
}