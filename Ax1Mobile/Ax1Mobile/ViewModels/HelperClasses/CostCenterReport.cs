using System.Linq;
using System.Collections.Generic;
using System;

namespace Ax1Mobile.ViewModels.HelperClasses
{
    /// <summary>
    /// Generates Reports based on Cost Centers or collections of Cost Centers
    /// </summary>
    public static class CostCenterReport
    {
        /// <summary>
        /// Computes the total cost (with regards to employees) for all Cost Centers.
        /// </summary>
        /// <param name="CostCenters"></param>
        /// <returns></returns>
        public static double TotalUSOppsCost(ICollection<CostCenter> costCenters)
        {
            if (costCenters == null)
            {
                throw new ArgumentNullException("costCenters");
            }

            double TotalCost = 0;

            try
            {
                foreach (Employee e in costCenters.SelectMany(c => c.CenterEmployees))
                {
                    TotalCost += e.AnnualPay;
                }
                return TotalCost;
            }
            catch (NullReferenceException)
            {
                TotalCost = 0;

                foreach (var c in costCenters)
                {
                    if (c.CenterEmployees != null)
                    {
                        foreach (var e in c.CenterEmployees)
                        TotalCost += e.AnnualPay;
                    }
                }
                return TotalCost;
            }
        }

        /// <summary>
        /// Computes the average cost of all employees for all cost centers.
        /// </summary>
        /// <param name="CostCenters"></param>
        /// <returns></returns>
        public static double AverageUSOppsCost(ICollection<CostCenter> costCenters)
        {
            if (costCenters == null)
            {
                throw new ArgumentNullException("costCenters");
            }

            double AverageCost = 0;
            double Count = 0;
            try
            { 
                foreach (CostCenter c in costCenters)
                {
                    Count++;
                }

                foreach (Employee e in costCenters.SelectMany(c => c.CenterEmployees))
                {
                    AverageCost = AverageCost + e.AnnualPay;
                }

                AverageCost = AverageCost / Count;

                return AverageCost;
            }   
            catch (NullReferenceException)
            {
                AverageCost = 0;
                Count = 0;

                foreach (CostCenter c in costCenters)
                {
                    Count++;
                }

                foreach (var c in costCenters)
                {
                    if (c.CenterEmployees != null)
                    {
                        foreach (var e in c.CenterEmployees)
                        {
                            AverageCost += e.AnnualPay;
                        }
                    }
                }
                AverageCost = AverageCost / Count;
                return AverageCost;
            }
}

        /// <summary>
        /// Computes the total cost (with regards to employees) for a Cost Center.
        /// </summary>
        /// <param name="CostCenters"></param>
        /// <returns></returns>
        public static double TotalCostCenterCost(CostCenter costCenter)
        {
            if (costCenter == null)
            {
                throw new ArgumentNullException("costCenter");
            }

            double TotalCost = 0;

            if (costCenter.CenterEmployees != null)
            {
                foreach (Employee e in costCenter.CenterEmployees)
                {
                    TotalCost += e.AnnualPay;
                }
            }
            return TotalCost;
        }
        
        /// <summary>
        /// returns the average cost of a CostCenter
        /// </summary>
        /// <param name="costCenter"></param>
        /// <returns></returns>
        public static double AverageCostCenterCost(CostCenter costCenter)
        {
            if (costCenter == null)
            {
                throw new ArgumentNullException("costCenter");
            }

            var Count = 0;
            double AverageCost = 0;

            if (costCenter.CenterEmployees != null)
            {
                foreach (Employee e in costCenter.CenterEmployees)
                {
                    Count++;
                    AverageCost = AverageCost + e.AnnualPay;
                }

                AverageCost = AverageCost / Count;
            }

            return AverageCost;
        }

        /// <summary>
        /// Retruns the total number of employees in a cost center list.
        /// </summary>
        /// <param name="costCenters"></param>
        /// <returns></returns>
        public static int TotalNumberOfUSEmployees(ICollection<CostCenter> costCenters)
        {
            if (costCenters == null)
            {
                throw new ArgumentNullException("costCenters");
            }

            var Count = 0;
            try
            { 
                foreach (Employee e in costCenters.SelectMany(c => c.CenterEmployees))
                {
                    Count += 1;
                }
                return Count;
            }
            catch (NullReferenceException)
            {
                Count = 0;

                foreach (var c in costCenters)
                {
                    if (c.CenterEmployees != null)
                    {
                        foreach (var e in c.CenterEmployees)
                            Count += 1;
                    }
                }
                return Count;
            }
}

        /// <summary>
        /// Returns the total number of employees in a cost center
        /// </summary>
        /// <param name="costCenter"></param>
        /// <returns></returns>
        public static int TotalNumberOfCostCenterEmployess(CostCenter costCenter)
        {
            if (costCenter == null)
            {
                throw new ArgumentNullException("costCenter");
            }

            var Count = 0;

            if (costCenter.CenterEmployees != null)
            {
                foreach (Employee e in costCenter.CenterEmployees)
                {
                    Count += 1;
                }
            }
            return Count;
        }

        /// <summary>
        /// Computes the average number of employees for all us cost centers.
        /// </summary>
        /// <param name="CostCenters"></param>
        /// <returns></returns>
        public static double AverageNumberOfEmployeesUSOpps(ICollection<CostCenter> costCenters)
        {
            if (costCenters == null)
            {
                throw new ArgumentNullException("costCenters");
            }

            double Average = 0;
            double CountE = 0;
            double CountC = 0;

            try
            { 
                foreach (CostCenter c in costCenters)
                {
                    CountC += 1;
                }
                foreach (Employee e in costCenters.SelectMany(c => c.CenterEmployees))
                {
                    CountE += 1;
                }
                Average = CountE / CountC;

                return Average;
            }
            catch (NullReferenceException)
            {
                Average = 0;
                CountE = 0;
                CountC = 0;

                foreach (CostCenter c in costCenters)
                {
                    CountC += 1;
                }
                foreach (var c in costCenters)
                {
                    if (c.CenterEmployees != null)
                    {
                        foreach (var e in c.CenterEmployees)
                            CountE += 1;
                    }
                }
                Average = CountE / CountC;

                return Average;
            }
}
    }
}
