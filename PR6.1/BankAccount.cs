using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR6._1
{
    /// <summary>
    /// Класс, представляющий банковский счет клиента.
    /// Хранит имя владельца счета и текущий баланс,
    /// а также позволяет выполнять операции списания и пополнения средств.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Сообщение об ошибке при попытке снять сумму больше текущего баланса.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Сообщение об ошибке при попытке снять отрицательную сумму.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        /// <summary>
        /// Сообщение об ошибке при попытке пополнить счет отрицательной суммой.
        /// </summary>
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";

        /// <summary>
        /// Создает новый банковский счет.
        /// </summary>
        /// <param name="customerName">Имя владельца счета.</param>
        /// <param name="balance">Начальный баланс счета.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Имя владельца счета.
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Текущий баланс счета.
        /// </summary>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Снимает деньги со счета.
        /// </summary>
        /// <param name="amount">Сумма списания.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если сумма больше текущего баланса
        /// или если сумма меньше нуля.
        /// </exception>
        /// <remarks>
        /// Если сумма списания корректна, она вычитается из текущего баланса счета.
        /// </remarks>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }

        /// <summary>
        /// Пополняет счет на указанную сумму.
        /// </summary>
        /// <param name="amount">Сумма пополнения.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Выбрасывается, если сумма пополнения меньше нуля.
        /// </exception>
        /// <remarks>
        /// При корректной сумме значение добавляется к текущему балансу счета.
        /// </remarks>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }

        /// <summary>
        /// Точка входа в консольное приложение.
        /// Демонстрирует работу операций пополнения и списания средств.
        /// </summary>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);

            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}
