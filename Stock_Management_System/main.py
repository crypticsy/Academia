#!/bin/bash

import os

# import custom functions
from message import startup_notification, end_of_program
from helper import user_option, file_to_list, display_all_laptop, sell_laptop, order_laptop

for folder in ['customer_purchase', 'manufacturer_order']:
    if not os.path.isdir(folder):
        os.mkdir(folder)


def main():
    # main infinite loop
    while True:

        # retrive user input
        startup_notification()
        user_choice = user_option()
        
        # load the laptops availabe in a list
        list_of_laptop = file_to_list('laptop')
        
        # logical actions based on user's input
        if user_choice == 1:
            display_all_laptop(list_of_laptop)

        elif user_choice == 2:
            sell_laptop(list_of_laptop)
            
        elif user_choice == 3:
            order_laptop(list_of_laptop)
            
        elif user_choice == 4:
            end_of_program()
            break
        

if __name__ == "__main__":
    print("\n***** Welcome to the Laptop Stock Management System *****")
    main()