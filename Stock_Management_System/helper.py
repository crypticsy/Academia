# import relevant libraries
import os
import datetime

# import custom functions
from message import press_to_continue



date_format = '%Y-%m-%d'                            # date format
time_format = '%H:%M:%S'                            # time format
date_time_format = date_format + " " + time_format  # date time format
decorator = '---------------------------------------------'

shipping_rate = 0.1                                 # shipping rate
vat_rate = 0.13                                     # vat rate


def user_option():
    """ Function to get choice from the user
    @return : int or None """

    try:
        opt = int(input("\nPlease select one of the numbers mentioned above: "))            # get option from user
        if opt >= 1 and opt <= 4: return opt                                                # if option is valid, return option 

        print("\nThe option you have selected is invalid. Please, enter a valid option.")     # error messsage
    except:
        print("\nThe option you have selected is invalid. Please, enter a valid option.")     # error messsage



def get_name(type):
    """ Function to get name for the given type
    @return : string """

    # infinite loop
    while True: 
        name = input(f"\nEnter your {type} name: ")
        if name.isalpha():                                      # check if name is valid string
            return name
        
        print("\n**Names can only be written from alphabets without spaces.**\n")



def get_quantity_choice(action):
    """ Function to get the quantity of for a laptop to either sell or buy
    @return : string """

    # infinite loop
    while True: 
        quantity = input(f"\nEnter your the quantity that you want to {action} : ")
        
        if quantity.isdigit():                                      # check if quantity is valid whole number
            return int(quantity)
        
        print("Quantity can only be a positive whole number.\n")



def get_laptop_choice(laptop_num, action):
    """ Function to get the laptop choice from the user
    @param : laptop_num - int, action - string
    @return : int """

    while True:
        try:
            num = int(input(f"\nEnter the laptop id you want to {action}: "))                   # get the laptop choice from the user
            if num >= 0 and num < laptop_num: return num                                             # if the laptop choice is valid, return the laptop choice
            print("\nThe laptop you have selected is invalid. Please, enter a valid laptop number.")      # error messsage    

        except:
            print("\nThe number you have entered is not valid. Please, enter a valid number.")        # error messsage






def file_to_list(filename):
    """ Function to get contents of a file in list
    @return : list """
    
    data = []

    with open(f"{filename}.txt", "r") as file:
        for line in file.readlines():                           # read each line
            data.append(line.strip(" \n").split(","))       # split the line and store the information in laptop variable

    return data



def list_to_file(filename, file_location, *args):
    """ Function to write the list to a file
    @param : filename - string, *args - list """

    with open(os.path.join(file_location, f"{filename}.txt"), "w") as file:
        for values in args:             # for each list in the argument
            for value in values:        # for each value in the list
                file.write(str(value)+"\n")



def display_all_laptop(list_of_laptop):
    """ Function to display all the laptop in the database 
    @param : list_of_laptop - list """

    print("\n***** The laptop that are currently available are: *****\n")

    # required variables
    index = ['id', ' Name', ' Brand', ' Price', ' Stock', ' Processor', ' Graphics Card']                            # index of the list
    display = [ "+", "| ", "+"] + [ "| " for _ in range(len(list_of_laptop))] + ["+"]

    for i in range(len(index)):
        # find the maximum spacing for the output
        maxim = max(len(index[i]), max([len(row[i]) for row in list_of_laptop])) + 1
        # generate border
        border = "-" * (maxim + 1) + "-+"
        
        # table generation
        display[0] += border
        display[1] += index[i].ljust(maxim) + " | "
        display[2] += border
        for row in range(len(list_of_laptop)):
            display[row+3] += list_of_laptop[row][i].ljust(maxim) + " | "

        display[-1] += border
    
    for row in display: print(row)
    press_to_continue()



def alter_stock(list_of_laptop, id, quantity):
    """ Function to alter the stock of a laptop
    @param : list_of_laptop - list, id - int, quantity - int 
    @return : boolean """

    with open("laptop.txt", "w") as file:
        valid, price = False, None

        for line in list_of_laptop:
            # if the laptop is a match and available, quantity the stock
            if id == int(line[0]):
                updated_quantity = int(line[4][1:]) + quantity
                
                if ( updated_quantity >= 0):
                    line[4] = " " + str(updated_quantity)    # update the stock
                    valid, price = True, abs(quantity) * float(line[3].replace("$", ""))
            
                else:
                    print("\n" + decorator)
                    print("The laptop is not in stock. Please try again.")
                    press_to_continue()
                
            line = ",".join(line)                       # join the values to form the initial string
            file.write(line+"\n")

        return valid, price



def sell_laptop(laptop_list):
        """ Function that allows a user to sell a laptop at a time 
        @param : laptop_list - list"""

        # get user and book details
        customer_name = get_name("customter")
        today_date = datetime.datetime.now().strftime(date_format)
        today_time = datetime.datetime.now().strftime(time_format)
        file_name = customer_name.replace(" ","_") + "_" + today_date.replace("-","_") + "_" + today_time.replace(":","_")
        
        # generate mandatory note detail
        transaction_meta_detail = [
            decorator,
            f"Customer name : {customer_name}",
            f"Date of purchase (YYYY-MM-DD) : {today_date}",
            f"Time of purchase (HH:MM:SS) : {today_time}",
            decorator
        ]

        transaction_list, total_cost = [], 0
        while True:
            laptop_num = get_laptop_choice(len(laptop_list), "sell")
            laptop_quantity = get_quantity_choice("sell")
            
            laptop_self_updated, purchase_cost = alter_stock(laptop_list, laptop_num, -laptop_quantity)

            if laptop_self_updated:
                laptop_list = file_to_list('laptop')
                
                # add laptop transaction details
                transaction_list.append([
                    f"Laptop Name : {laptop_list[laptop_num][1]}",
                    f"Brand Name : {laptop_list[laptop_num][2]}",
                    f"Purchase Cost : " + "${:.2f}".format(purchase_cost),
                    decorator
                ])
                total_cost += purchase_cost

                # display the laptop details
                print("\n***** The laptop stock has been updated successfully. *****\n")
                for i in transaction_meta_detail + transaction_list[-1]:
                    print(i)
                
                press_to_continue()

            # check if the user wants to sell another laptop
            end_loop = False
            while True:
                choice = input("\nDo you want to sell another laptop? (y/n): ")
                if choice == "y" or choice=="Y":
                    break
                elif choice == "n" or choice=="N":
                    end_loop = True
                    break
                else:
                    print("\nPlease enter a valid option.")
            
            if end_loop: break


        if transaction_list:
            shipping_cost = total_cost * shipping_rate
            transaction_list.append([
                f"Net amount (without shipping rate) : "+ "${:.2f}".format(total_cost),
                f"Shipping amount : "+ "${:.2f}".format(shipping_cost),
                f"Total amount : "+ "${:.2f}".format(total_cost + shipping_cost),
                decorator
            ])
            list_to_file(file_name, "customer_purchase", transaction_meta_detail, *transaction_list)



def order_laptop(laptop_list):
        """ Function that allows a user to order new laptop at a time 
        @param : laptop_list - list"""

        # get user and book details
        distributor_name = get_name("distributor (company)")
        today_date = datetime.datetime.now().strftime(date_format)
        today_time = datetime.datetime.now().strftime(time_format)
        file_name = distributor_name.replace(" ","_") + "_" + today_date.replace("-","_") + "_" + today_time.replace(":","_")
        
        # generate mandatory note detail
        transaction_meta_detail = [
            decorator,
            f"Distributor (company) name : {distributor_name}",
            f"Date of order (YYYY-MM-DD) : {today_date}",
            f"Time of order (HH:MM:SS) : {today_time}",
            decorator
        ]

        transaction_list, total_cost = [], 0
        while True:
            laptop_num = get_laptop_choice(len(laptop_list), "order")
            laptop_quantity = get_quantity_choice("order")
            
            laptop_self_updated, purchase_cost = alter_stock(laptop_list, laptop_num, laptop_quantity)

            if laptop_self_updated:
                laptop_list = file_to_list('laptop')
                
                # add laptop transaction details
                transaction_list.append([
                    f"Laptop Name : {laptop_list[laptop_num][1]}",
                    f"Brand Name : {laptop_list[laptop_num][2]}",
                    f"Order Cost : " + "${:.2f}".format(purchase_cost),
                    decorator
                ])
                total_cost += purchase_cost

                # display the laptop details
                print("\n***** The laptop stock has been updated successfully. *****\n")
                for i in transaction_meta_detail + transaction_list[-1]:
                    print(i)
                
                press_to_continue()

            # check if the user wants to order another laptop
            end_loop = False
            while True:
                choice = input("\nDo you want to order another laptop? (y/n): ")
                if choice == "y" or choice=="Y":
                    break
                elif choice == "n" or choice=="N":
                    end_loop = True
                    break
                else:
                    print("\nPlease enter a valid option.")
            
            if end_loop: break


        if transaction_list:
            vat_cost = total_cost * vat_rate
            transaction_list.append([
                f"Net amount (without VAT) : "+ "${:.2f}".format(total_cost),
                f"VAT amount : "+ "${:.2f}".format(vat_cost),
                f"Total amount : "+ "${:.2f}".format(total_cost + vat_cost),
                decorator
            ])
            list_to_file(file_name, "manufacturer_order", transaction_meta_detail, *transaction_list)