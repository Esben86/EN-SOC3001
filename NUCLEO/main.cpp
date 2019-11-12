#include "mbed.h"

Serial pc(USBTX, USBRX); // tx, rx
int recievedValue, present;
char s[20];
BusOut StepMotor(PA_9, PC_7, PB_6, PA_7);
        
void CW() {
    StepMotor = 0x9; // 1001
    wait_ms(10);
    StepMotor = 0xC; // 1100
    wait_ms(10);
    StepMotor = 0x6; // 0110
    wait_ms(10);
    StepMotor = 0x3; // 0011
    wait_ms(10);
    present++;
    pc.printf("%6.2f \n", (present*360/(float)512));
    }
    
void CCW() {
    StepMotor = 0x6; // 1001
    wait_ms(10);
    StepMotor = 0xC; // 1100
    wait_ms(10);
    StepMotor = 0x9; // 0110
    wait_ms(10);
    StepMotor = 0x3; // 0011
    present--;
    pc.printf("%6.2f \n", (present*360/(float)512));
    }
    
void Rx_interrupt() {
    if (pc.readable()) { 
        pc.gets(s,20);
        // pc.puts(s);
                
        recievedValue = atoi(s);
                
        if (recievedValue == 1) {
            CW();
        } else if (recievedValue == 2) {
            CCW();
        }
    } 
}   
    
int main() { 
    pc.baud(9600);
    present = 0;
    
    // Setup a serial interrupt function to receive data
    pc.attach(&Rx_interrupt, Serial::RxIrq);

    while (true) {
        
    }
}