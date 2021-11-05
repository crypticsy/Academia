def startup_notification():
    """ Function that displays the initial message for the user to interact with the system """

    print("\nPlease enter one of the following options:\n")
    print("Enter 1: To display available books.")
    print("Enter 2: To return a book.")
    print("Enter 3: To borrow a book.")
    print("Enter 4: To exit.")


def press_to_continue():
    """ Function that asks the user to press any key to continue """

    input("\nPress any key to continue...")


def end_of_program():
    """ Function that displays a message when the user has finished using the system """

    print("\nThank you for using the library system.\n") 
