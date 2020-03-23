﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Calculator.ViewModels.Base;

namespace Calculator.ViewModels
{
    class StandardCalculatorViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// Current expression to count
        /// </summary>
        private string currentExpression = "";

        /// <summary>
        /// Current entered number
        /// </summary>
        private string currentNumber = "0";

        #endregion

        #region Public properties

        /// <summary>
        /// 
        /// </summary>
        public string CurrentExpression
        {
            get
            {
                return currentExpression;
            }
            set
            {
                currentExpression = value;
                OnPropertyChanged(nameof(CurrentExpression));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CurrentNumber
        {
            get
            {
                return currentNumber;
            }
            set
            {
                currentNumber = value;
                OnPropertyChanged(nameof(CurrentNumber));
            }
        }

        #endregion

        #region Commands

        #region Commands for memory operations

        /// <summary>
        /// Erases numbers stored in memory
        /// </summary>
        public ICommand MemoryClearCommand { get; }

        /// <summary>
        /// Reading value from memory
        /// </summary>
        public ICommand MemoryReadCommand { get; }

        /// <summary>
        /// Adds the current number to the one stored in memory
        /// </summary>
        /// <remarks>
        /// The default value in memory is 0
        /// </remarks>
        public ICommand MemoryPlusCommand { get; }

        /// <summary>
        /// Subtracts the current number from the number stored in memory
        /// </summary>
        /// <remarks>
        /// The default value in memory is 0
        /// </remarks>
        public ICommand MemoryMinusCommand { get; }

        /// <summary>
        /// Saves the current number in memory for later use
        /// </summary>
        public ICommand MemorySaveCommand { get; }

        /// <summary>
        /// View the number stored in memory
        /// </summary>
        public ICommand MemoryHistoryCommand { get; }

        #endregion

        #region Commands for additional operations

        /// <summary>
        /// Erases all previously entered data
        /// </summary>
        /// <remarks>
        /// At the same time, the numbers recorded in the memory are stored
        /// </remarks>
        public ICommand ClearCommand { get; }

        /// <summary>
        /// Erases the last entered number
        /// </summary>
        public ICommand ClearEntryCommand { get; }

        /// <summary>
        /// Erases the last digit entered in the current number
        /// </summary>
        public ICommand BackspaceCommand { get; }

        /// <summary>
        /// Finds a percentage of the current expression
        /// </summary>
        public ICommand FindPercentageCommand { get; }

        /// <summary>
        /// Allows you to find out how much the current number is from a single whole
        /// </summary>
        public ICommand PartOfTheWholeCommand { get; }

        /// <summary>
        /// Square of the current number
        /// </summary>
        public ICommand SquaredNumberCommand { get; }

        /// <summary>
        /// Square root of the current number
        /// </summary>
        public ICommand SqrtCommand { get; }

        #endregion

        #region Commands for basic math operations

        /// <summary>
        /// Adds a division operation to an expression
        /// </summary>
        public ICommand DivisionCommand { get; }

        /// <summary>
        /// Adds a multiply operation to an expression
        /// </summary>
        public ICommand MultiplyCommand { get; }

        /// <summary>
        /// Adds a subtraction operation to an expression
        /// </summary>
        public ICommand SubtractionCommand { get; }

        /// <summary>
        /// Adds an addition operation to an expression
        /// </summary>
        public ICommand AdditionCommand { get; }

        /// <summary>
        /// Counts the value of the current expression
        /// </summary>
        public ICommand EquallyCommand { get; }

        #endregion

        #region Number pad commands

        /// <summary>
        /// Adds number 0 to the current number
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public ICommand NumberZeroCommand { get; }

        /// <summary>
        /// Adds number 1 to the current number
        /// </summary>
        public ICommand NumberOneCommand { get; }

        /// <summary>
        /// Adds number 2 to the current number
        /// </summary>
        public ICommand NumberTwoCommand { get; }

        /// <summary>
        /// Adds number 3 to the current number
        /// </summary>
        public ICommand NumberThreeCommand { get; }

        /// <summary>
        /// Adds number 4 to the current number
        /// </summary>
        public ICommand NumberFourCommand { get; }

        /// <summary>
        /// Adds number 5 to the current number
        /// </summary>
        public ICommand NumberFiveCommand { get; }

        /// <summary>
        /// Adds number 6 to the current number
        /// </summary>
        public ICommand NumberSixCommand { get; }

        /// <summary>
        /// Adds number 7 to the current number
        /// </summary>
        public ICommand NumberSevenCommand { get; }

        /// <summary>
        /// Adds number 8 to the current number
        /// </summary>
        public ICommand NumberEightCommand { get; }

        /// <summary>
        /// Adds number 9 to the current number
        /// </summary>
        public ICommand NumberNineCommand { get; }

        /// <summary>
        /// Inverts the sign of the current number
        /// </summary>
        public ICommand InvertSignCommand { get; }

        /// <summary>
        /// Makes the current number real
        /// </summary>
        public ICommand CommaCommand { get; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public StandardCalculatorViewModel()
        {
            //Objects initialization


            //сейчас все команды работают не корректно (вообще не работают)
            //вынести всю реализацию команд в отдельные классы
            #region Create commands

            #region Commands for memory operations
            /*
            MemoryClearCommand = ;
            MemoryReadCommand = ;
            MemoryPlusCommand = ;
            MemoryMinusCommand = ;
            MemorySaveCommand = ;
            MemoryHistoryCommand = ;
            */
            #endregion

            #region Commands for additional operations

            ClearCommand = new RelayCommand(() => { CurrentNumber = "0"; CurrentExpression = ""; });
            ClearEntryCommand = new RelayCommand(() => { if (CurrentNumber != "0") { CurrentNumber = "0"; } });
            BackspaceCommand = new RelayCommand(() => 
            { 
                if (CurrentNumber[0] != '-') 
                {
                    if (CurrentNumber.Length != 1) 
                        CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1); 
                    else if (CurrentNumber != "0") 
                        CurrentNumber = "0"; 
                }
                else
                {
                    if (CurrentNumber.Length != 2)
                        CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                    else
                        CurrentNumber = "0";
                }
            });
            
            FindPercentageCommand = new RelayCommand(() => MessageBox.Show(currentNumber));
            //PartOfTheWholeCommand = ;
            //SquaredNumberCommand = ;
            //SqrtCommand = ;

            #endregion

            #region Commands for basic math operations

            DivisionCommand = new RelayCommand(() => { CurrentExpression += CurrentNumber + " ÷ "; });
            MultiplyCommand = new RelayCommand(() => { CurrentExpression += CurrentNumber + " × "; });
            SubtractionCommand = new RelayCommand(() => { CurrentExpression += CurrentNumber + " - "; });
            AdditionCommand = new RelayCommand(() => { CurrentExpression += CurrentNumber + " + "; });
            EquallyCommand = new RelayCommand(() => { CurrentExpression += CurrentNumber + " = "; });

            #endregion

            #region Number pad commands

            NumberZeroCommand = new RelayCommand(() => { if (CurrentNumber!="0") CurrentNumber += '0'; });
            NumberOneCommand = new RelayCommand(() => { if (CurrentNumber != "0") CurrentNumber += '1'; else CurrentNumber = "1"; });
            NumberTwoCommand = new RelayCommand(() => { if (CurrentNumber != "0") CurrentNumber += '2'; else CurrentNumber = "2"; });
            NumberThreeCommand = new RelayCommand(() => { if (CurrentNumber != "0") CurrentNumber += '3'; else CurrentNumber = "3"; });
            NumberFourCommand = new RelayCommand(() => { if (CurrentNumber != "0") CurrentNumber += '4'; else CurrentNumber = "4"; });
            NumberFiveCommand = new RelayCommand(() => { if (CurrentNumber != "0") CurrentNumber += '5'; else CurrentNumber = "5"; });
            NumberSixCommand = new RelayCommand(() => { if (CurrentNumber != "0") CurrentNumber += '6'; else CurrentNumber = "6"; });
            NumberSevenCommand = new RelayCommand(() => { if (CurrentNumber != "0") CurrentNumber += '7'; else CurrentNumber = "7"; });
            NumberEightCommand = new RelayCommand(() => { if (CurrentNumber != "0") CurrentNumber += '8'; else CurrentNumber = "8"; });
            NumberNineCommand = new RelayCommand(() => { if (CurrentNumber != "0") CurrentNumber += '9'; else CurrentNumber = "9"; });
            InvertSignCommand = new RelayCommand(() => { if (CurrentNumber != "0") { if (CurrentNumber.IndexOf('-') == -1) CurrentNumber = CurrentNumber.Insert(0, "-"); else CurrentNumber = CurrentNumber.Remove(0, 1); } });
            CommaCommand = new RelayCommand(() => { if (CurrentNumber.IndexOf(',') == -1) CurrentNumber += ',';});

            #endregion
            
            #endregion
        }

        #endregion
    }
}