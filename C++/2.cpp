//Positive or Negative number: 
#include<iostream>
using namespace std;
void  posOrNeg(int n){
     if(n>0){
         cout<<"This number is positive";
     }
     else if(n==0){
         cout<<"This is zero";
     }
     else{
         cout<<"This is not positive";
     }
 }
int main(){
    posOrNeg(5);
    return 0;
}