#!/bin/bash

# import custom functions
from message import startup_notification, end_of_program
from helper import user_option, file_to_list, display_all_books, borrow_book, return_book




def main():
    # main infinite loop
    while True:

        # retrive user input
        startup_notification()
        user_choice = user_option()
                
        # load the books availabe in a list
        list_of_book = file_to_list('books')
        
        # logical actions based on user's input
        if user_choice == 1:
            display_all_books(list_of_book)

        elif user_choice == 2:
            return_book(list_of_book)
            
        elif user_choice == 3:
            borrow_book(list_of_book)
            
        elif user_choice == 4:
            end_of_program()
            break
        

if __name__ == "__main__":
    print("\n***** Welcome to the Library Management System *****")
    main()