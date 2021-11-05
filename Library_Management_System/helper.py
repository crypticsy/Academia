# import relevant libraries
import os
import datetime

# import custom functions
from message import press_to_continue



date_format = '%Y-%m-%d'                            # date format
time_format = '%H:%M:%S'                            # time format
date_time_format = date_format + " " + time_format  # date time format
decorator = '---------------------------------------------'
overdue_fee_per_day = 1.80

def user_option():
    """ Function to get choice from the user
    @return : int or None """

    try:
        opt = int(input("\nPlease select one of the numbers mentioned above: "))            # get option from user
        if opt >= 1 and opt <= 4: return opt                                                # if option is valid, return option 

        print("\nThe option you have selected is invalid. Please, enter a valid option.")     # error messsage
    except:
        print("\nThe option you have selected is invalid. Please, enter a valid option.")     # error messsage



def get_username():
    """ Function to get username from the current user
    @return : string """

    # infinite loop
    while True: 
        name = input("\nEnter your name: ")
        if name.isalpha():                                      # check if name is valid string
            return name
        print("Names can only be written from alphabets.\n")



def get_bookchoice(book_num, action):
    """ Function to get the book choice from the user
    @param : book_num - int, action - string
    @return : int """

    while True:
        try:
            num = int(input(f"\nEnter the book id you want to {action}: "))                   # get the book choice from the user
            if num >= 0 and num <= book_num: return num                                             # if the book choice is valid, return the book choice
            print("\nThe book you have selected is invalid. Please, enter a valid book number.")      # error messsage    

        except:
            print("\nThe number you have entered is not valid. Please, enter a valid number.")        # error messsage






def file_to_list(filename):
    """ Function to get contents of a file in list
    @return : list """
    
    book = []

    # open the book.txt file in "read" mode 
    with open(f"{filename}.txt", "r") as file:
        for line in file.readlines():                           # read each line
            book.append(line.strip(" \n").split(","))       # split the line and store the information in book variable

    return book



def list_to_file(filename, file_location, *args):
    """ Function to write the list to a file
    @param : filename - string, *args - list """

    with open(os.path.join(file_location, f"{filename}.txt"), "w") as file:
        for values in args:             # for each list in the argument
            for value in values:        # for each value in the list
                file.write(str(value)+"\n")



def display_all_books(list_of_book):
    """ Function to display all the books in the database 
    @param : list_of_book - list """

    print("\n***** The books that are currently available are: *****\n")

    # required variables
    index = ['id', ' Name', ' Author' , ' Stock', ' Price']                            # index of the list
    display = [ "+", "| ", "+"] + [ "| " for _ in range(len(list_of_book))] + ["+"]

    for i in range(5):
        # find the maximum spacing for the output
        maxim = max(len(index[i]), max([len(row[i]) for row in list_of_book])) + 1
        # generate border
        border = "-" * (maxim + 1) + "-+"
        
        # table generation
        display[0] += border
        display[1] += index[i].ljust(maxim) + " | "
        display[2] += border
        for row in range(len(list_of_book)):
            display[row+3] += list_of_book[row][i].ljust(maxim) + " | "

        display[-1] += border
    
    for row in display: print(row)
    press_to_continue()



def alter_stock(list_of_book, num, update):
    """ Function to alter the stock of a book
    @param : list_of_book - list, num - int, update - int 
    @return : boolean """

    with open("books.txt", "w") as file:
        valid, price = False, None

        for line in list_of_book:
            # if the book is a match and available, update the stock
            if num == int(line[0]) and ( update == 1 or (line[3] != "0" and update == -1)):
                line[3] = " "+str(int(line[3]) + update)    # update the stock
                valid, price = True, float(line[4].replace("$", ""))
            
            elif num == int(line[0]):
                print("The book is not in stock. Please try again.")
                press_to_continue()
                
            line = ",".join(line)                       # join the values to form the initial string
            file.write(line+"\n")

        return valid, price






def borrow_book(book_list):
        """ Function that allows a user to borrow a single book at a time 
        @param : book_list - list"""

        # get user and book details
        name = get_username()
        today_date = datetime.datetime.now().strftime(date_format)
        today_time = datetime.datetime.now().strftime(time_format)
        file_name = name + "_" + today_date.replace("-","_") + "_" + today_time.replace(":","_")

        # generate mandatory note detail
        transaction_meta_detail = [
            decorator,
            f"Client (Borrower) name : {name}",
            f"Date of borrow (YYYY-MM-DD) : {today_date}",
            f"Time of borrow (HH:MM:SS) : {today_time}",
            decorator
        ]

        transaction_list, total_cost = [], 0
        while True:
            book_num = get_bookchoice(len(book_list), "borrow")
            book_self_updated, price = alter_stock(book_list, book_num, -1)

            if book_self_updated:
                with open("ticket.txt", "a") as file:
                    # add a record in the ticket file to ensure future callback to the ticket
                    values = [  name, 
                                str(book_num), 
                                today_date + " " + today_time, 
                                "-", 
                                "$0.00"]

                    file.write(', '.join(values)+"\n")

                    # add book transaction details for ticket generation
                    transaction_list.append([
                        f"Name of book : {book_list[book_num][1]}",
                        f"Borrow fee : " + "${:.2f}".format(price),
                        decorator
                    ])
                    total_cost += price                    

                    # display the book details
                    print("\n***** The book self has been updated successfully. *****\n")
                    for i in transaction_meta_detail + transaction_list[-1]:
                        print(i)
                    press_to_continue()

            # check if the user wants to book another book
            end_loop = False
            while True:
                choice = input("\nDo you want to borrow another book? (y/n): ")
                if choice == "y" or choice=="Y":
                    break
                elif choice == "n" or choice=="N":
                    end_loop = True
                    break
                else:
                    print("\nPlease enter a valid option.")
            
            if end_loop: break


        if transaction_list:
            transaction_list.append([
                f"Total cost : "+ "${:.2f}".format(total_cost),
                decorator
            ])
            list_to_file(file_name, "borrow", transaction_meta_detail, *transaction_list)



def return_book(book_list):
        """ Function that allows a user to borrow a single book at a time 
        @param : book_list - list"""

        # get user and book details
        name = get_username()
        today_date = datetime.datetime.now().strftime(date_format)
        today_time = datetime.datetime.now().strftime(time_format)
        file_name = name + "_" + today_date.replace("-","_") + "_" + today_time.replace(":","_")

        # generate mandatory note detail
        transaction_meta_detail = [
            decorator,
            f"Client (Returner) name : {name}",
            f"Date of return (YYYY-MM-DD) : {today_date}",
            f"Time of return (HH:MM:SS) : {today_time}",
            decorator
        ]

        transaction_list, total_cost = [], 0
        while True:
            book_num = get_bookchoice(len(book_list), "return")
            all_actions = file_to_list('ticket')
            
            detail, overdue_fee = None, 0
            with open("ticket.txt", "w") as file:
                for row in all_actions:
                    if detail == None and row[0].strip() == name and row[1].strip() == str(book_num):
                        row[3] = " "+today_date
                        diff = datetime.datetime.strptime(today_date+" "+today_time, date_time_format) - datetime.datetime.strptime(row[2].strip(), date_time_format)
                        
                        if diff.days > 10:
                            overdue_fee = diff.days * overdue_fee_per_day
                            row[4] = " ${:.2f}".format(overdue_fee) 

                        detail = row.copy()

                    else:
                        file.write(','.join(row)+"\n")

            if detail:
                _, price = alter_stock(book_list, book_num, 1)

                # add book return details for ticket generation
                transaction_list.append([
                    f"Name of book : {book_list[int(detail[1])][1]}",
                    f"Borrow fee : " + "${:.2f}".format(price),
                    f"Overdue days : {diff} day/s" ,
                    f"Overdue fee per day : "+"${:.2f}".format(overdue_fee),
                    f"Overdue fee total : {detail[4]}" ,
                    decorator
                ])
                total_cost += price + overdue_fee                   

                # display the book details
                print("\n***** The book self has been updated successfully. *****\n")
                for i in transaction_meta_detail + transaction_list[-1]:
                    print(i)
                press_to_continue()

            else:
                print("\n*** The input doesn't have any match in our databse. Please check your input. ***")

            # check if the user wants to book another book
            end_loop = False
            while True:
                choice = input("\nDo you want to return another book? (y/n): ")
                if choice == "y" or choice=="Y":
                    break
                elif choice == "n" or choice=="N":
                    end_loop = True
                    break
                else:
                    print("\nPlease enter a valid option.")
            
            if end_loop: break


        if transaction_list:
            transaction_list.append([
                f"Total cost : "+ "${:.2f}".format(total_cost),
                decorator
            ])
            list_to_file(file_name, "return", transaction_meta_detail, *transaction_list)