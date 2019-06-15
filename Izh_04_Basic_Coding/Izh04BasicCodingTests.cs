﻿using System;
using NUnit.Framework;
using MSUnitTest = Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using TasksLibrary;
using System.Data;

namespace Izh_04_Basic_Coding
{
    using System.IO;
    using System.Linq;
    using MSUnitTestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

    [TestFixture]
    [MSUnitTest.TestClass]
    public class Izh04BasicCodingTests
    {
        public MSUnitTestContext TestContext { get; set; }
        TaskWorker tWorker = new TaskWorker();

        [MSUnitTest.TestMethod]
        public void CheckInsertNumberMSUnitTests()
        {
            MSUnitTest.Assert.AreEqual(tWorker.InsertNumber(int.MaxValue, 8, 4, 10), 2147481743);
            MSUnitTest.Assert.AreEqual(tWorker.InsertNumber(int.MinValue, -10, 20, 30), -10485760);
            MSUnitTest.Assert.AreEqual(tWorker.InsertNumber(7, 7, 4, 5), 55);
            MSUnitTest.Assert.AreEqual(tWorker.InsertNumber(1, 101, 0, 1), 1);
        }


        [TestCase(-9999, 42, 0, 10, ExpectedResult = -8234)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(999, -452, 2, 7, ExpectedResult = 787)]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int CheckInsertNumber(int numberSource, int numberIn, int i, int j)
        {
            return tWorker.InsertNumber(numberSource, numberIn, i, j);
        }

        [TestCase(9783, ExpectedResult = new bool[32] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, true, true, false, false, false, true, true, false, true, true, true })]
        [TestCase(-137, ExpectedResult = new bool[32] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true, false, false, true })]
        [TestCase(8, ExpectedResult = new bool[32] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false })]
        [TestCase(1, ExpectedResult = new bool[32] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true })]
        public bool[] CheckConvertNumberToBitArray(int number)
        {
            var type = typeof(TaskWorker);
            var instance = Activator.CreateInstance(type);

            var method = tWorker.GetType()
                .GetMethod("ConvertNumberToBitArray", BindingFlags.NonPublic | BindingFlags.Instance);

            return (bool[])method.Invoke(instance, new object[] { number });
        }

        [TestCase(new bool[] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, true, false, false, true }, ExpectedResult = -137)]
        [TestCase(new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false }, ExpectedResult = 8)]
        [TestCase(new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }, ExpectedResult = 1)]
        [TestCase(new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, true, true, false, false, false, true, true, false, true, true, true }, ExpectedResult = 9783)]
        public int CheckConvertBitArrayToNumber(bool[] arr)
        {
            var type = typeof(TaskWorker);
            var instance = Activator.CreateInstance(type);

            var method = tWorker.GetType()
                .GetMethod("ConvertBitArrayToNumber", BindingFlags.NonPublic | BindingFlags.Instance);

            return (int)method.Invoke(instance, new object[] { arr });
        }

        [TestCase(new int[] { int.MaxValue }, ExpectedResult = int.MaxValue)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 0, -1, 11, 21, 1, 2, 8, 65, 34, 21, 765, -12, 566, 7878, -199, 0, 34, 65, 87, 12, 34 }, ExpectedResult = 7878)]
        public int CheckMaxElementFinding(int[] sourceArray)
        {
            return tWorker.FindMaxElementInArray(sourceArray);
        }

        [Test]
        public void CheckMaxElementFindingNullArgument()
        {
            NUnit.Framework.Assert.Throws<ArgumentNullException>(
                () => tWorker.FindMaxElementInArray(null));
        }

        [TestCase(new double[] { }, ExpectedResult = -1)]
        [TestCase(new double[] { 0, 1, 2, 3 }, ExpectedResult = -1)]
        [TestCase(new double[] { 1, 2, 2, 3 }, ExpectedResult = 2)]
        [TestCase(new double[] { 49.2, 35.36, 38.94, 45.37, 44.16, 35.41, 21.61, 27.89, 28.58, 34.82, 28.17, 9.27, 5.41, 37.19, 30.55, 29.23, 37.3, 15.71, 21.33, 13.25, 18.05, 13.61, 30.12, 23.14, 10.89, 26.24, 10.04, 15.75, 38.75, 4.01, 15.17, 23.89, 5.22, 43.34, 37.06, 3.04, 47.04, 40.42, 31, 15.31, 10.22, 40.34, 36.42, 4.05, 28.47, 29.61, 16.67, 5.99, 28.92, 43.35, 7.33, 46.36, 14.77, 4.66, 3.26, 25.13, 32.78, 6.94, 22.42, 18.88, 4.15, 38.17, 21.95, 33.69, 8.03, 16.45, 19.66, 19.92, 22, 45.47, 8.33, 43.63, 40.46, 32.27, 43.01, 37.07, 39.08, 42.76, 32.63, 35.82, 38.75, 17.93, 7.82, 29.3, 33.04, 33.17, 37.29, 26.2, 43.23, 31.5, 11.73, 42.44, 6.11, 2.81, 1.43, 21.72, 38.86, 16.75, 26.05, 36.74, 18.63, 20, 8.48, 45.89, 38.02, 33.4, 0.01 }, ExpectedResult = 54)]
        [TestCase(new double[] { 156.74, 236.31, -298.16, -355.2, 472.41, 406.22, 147.06, 328.05, -96.67, 346.73, -302.72, 185.53, -27.15, 158.85, 3.26, -395.71, -1.78, -76.11, 460.31, 215.92, -145.8, -244, 172.46, 148.54, 26.25, -207.69, 363.03, -377.07, -433.81, -295.61, -140.94, -115.76, -392.83, 337.8, -377.02, -170.26, 253.65, 165.79, 387.31, -139.52, -33.31, -157.88, -344.86, 323.54, 256.56, 491.9, 99.65, -485.65, -482.19, -386.44, 119.23, -95.35, 54.82, -206.65, 379.46, -334.29, 13.67, -469.6, -439.25, 326.98, 8.65, 302.23, -73.55, 373.59, -394.26, -357.96, 180.81, 70.94, 2.46, -80.87, -230.73, 78.06, -21.21, -296.43, 244.41, 110.41, -246.17, 333.6, -288.51, -388.24, -361.83, -89.84, 179.94, -187.75, -37.5, -43.66, -401.2, -226.69, -304.2, -3.29, 65.7, 296.23, 7.7, 69.98, 464.65, 155.05, 308.84, 248.58, -251.57, 40.7, -437.58, -455.7, -398.87, 100.91, -204.3, -433.75, -70.54, 128.97, 370.77, -256.62, 450.13, 250.76, -372.97, -434.31, -468.97, -416.65, 43.86, -11.62, 425.67, -54.86, -256.92, -47.49, 399.22, 360.07, 259.22, 193.94, -59.1, -51.94, -331.25, 344.39, 432.94, -60.64, -249.71, 163.07, -429.4, -55.77, 83.25, -67.17, 390.45, 305.29, 253.97, -255.78, -469.03, 431.37, 450.25, -153.43, -235.46, 207.5, -480.73, -50.56, 287.04, 439.4, -213.35, 33.21, 151.42, -111.18, 446.88, 32.84, 331.11, 73.3, 13.9, 119.08, 491.85, 57.45, 409.66, 429.03, 401.91, 137.81, 127.09, -488.48, -269.98, 175.83, 399.79, 227.6, 237.18, 339.9, -432.85, -442.04, 173.64, -123.08, 345.56, -33.25, 213.15, -477.85, -283.71, -241.35, -370.31, -178.54, -161.97, 20.63, -154.68, -78.02, -57.25, 452.43, 408.3, -289.6, -19.77, -222.43, -457.18, 96.91, -295.81, -32.21, -99.71, -252.6, 424.5, 289.25, 1.34, 178.37, -141.96, 199.01, 273.44, -189.24, -281, -171.48, -283.85, -67.27, -214.09, 423.37, -211.31, 470.89, 55.49, -375.36, 398.32, 106.77, -479.03, -410.01, 222.54, -401.45, -441.81, 386.58, 479.15, -144.71, 352.3, -150.53, -480.52, -392.72, -491.75, 351.55, -303.62, -198.8, 29.46, -234.86, -217.54, -19.86, -444.26, 82.81, 24.86, -427.45, -381.16, -138.41, 276.43, 135.35, 226.67, -3.78, 339.31, -314.2, -237.27, -436.01, 304.84, 81.4, 29.98, -211.35, -72.93, -207.66, 364.94, 367.41, -62.1, 79.6, -421.26, 438.77, -69.94, -184.91, 492.34, 39.95, 71.4, -211.94, 497.01, 321.5, -240.79, 253.35, -471.82, -66.19, -286.46, -182.18, 452.95, 3.27, 41.47, -211.62, 442.4, 182.63, -78.53, -414.93, 124.82, 229.18, -27.8, 337.51, 157.21, 67.22, -24.52, -5.91, 158.33, -40.35, -2.64, 361.42, 147.21, 207.71, 278.74, -32.65, 103.52, -379.72, 359.81, 362.15, -22.18, -239.05, -476.12, -416.73, 415.05, 76.07, 175.99, -359.38, 105.08, 58.05, -222.77, -183.14, -297.93, 448.97, 301.64, -45.52, -288.83, -191.5, 78.61, -478.54, 464.51, 405.76, -444.87, -82.46, 345.78, -216.86, -420.86, -301.69, -359.24, -413.95, -211.15, -460.39, -233.75, 139.7, -12.72, 230.54, 295.96, -182.05, 111.92, -192.4, -228.29, -473.57, -468.09, 259.55, -215.19, -102.01, 236.57, 276.93, 485.28, -267.7, -465.4, 388.55, 342.02, 290.34, 35.54, -393.56, -410.38, -439.07, -124.8, -262.99, 137.09, -444.91, 298.11, 218.96, 294.02, 291.8, 414.97, -228.4, 161.13, -388.05, -169.88, 38.69, -293.44, 66.44, -373.11, -243.32, 412.68, 413.13, 477.44, -149.55, -44.35, 57.87, -233.78, 262.58, 492.73, -2.33, -343.26, -105.65, -29.77, 33.27, 189.26, -111.65, -72.59, -24.56, 230.05, 328.48, -378.35, 163.42, 351.78, 456.81, 162.86, 23.7, -114.13, -411.71, 388.51, -370.17, -31.57, 399.05, 195.9, 149.03, -433.75, 39.15, -305.65, 219.54, -393.8, -376.65, -298.5, -211.79, 180.82, 66.41, 126.12, -34.3, -459.29, -67.71, -401.68, 168.4, 170.02, 402.36, 260.09, 434.31, -426.88, 462.66, -309.04, -424.63, 65.09, -161, 312.9, -71.82, 307.46, 204.97, -337.32, -141.84, -74.93, 42.67, -294.78, 131.91, 437.36, 499.28, 205.43, 236.31, 181.7, -39.36, 162.59, 161.55, 190.02, -15.62, 155.46, -372.77, 228.34, 73.23, 117.79, 40.63, -377.11, 386.85, 223.59, 62.22, 258.48, 19.6, -78.71, -409.6, -242.63, -348.61, -375.08, 166.92, -483.54, -29.59, 314.9, 184.03, 193.65, 17.52, 457.32, -224.56, 75.48, -8.81, 216.39, 233.08, 481.84, 164.21, -39.37, 300.3, -173.69, -473.03, -286.29, -106.43, 221.11, -411.37, -231.68, -273.43, -370.95, 84.59, 357.8, 486.97, -456.39, -332.13, 167.25, -256.33, 64.67, -150.28, 231.92, -89.84, 488.85, -31.2, 357.35, -249.45, 70.03, -152.32, -297.96, -154.69, 197.51, 78.7, -416.1, -261.77, -468.55, -151.06, -437.34, 306.74, -384.63, 291.93, 385.4, 358.45, 300.01, 403.39, -10.43, -15.12, -351.32, 77.31, 112.75, 411.13, 319.02, 23.95, 368.28, -457.87, -319.79, 181.26, -228.58, 372.68, -399.77, -437.81, 230.6, -50.91, 86.15, -375.33, -423.28, 69.73, -346.21, 458.98, 472.51, -70.75, 479.04, 221.91, -11.16, 316.57, 20.51, 74.92, 414.19, 126.24, -420.93, -172.91, 148.44, 147.14, 402.09, -195.4, 417.69, 229.54, 70.9, -1.14, 499.14, -267.94, -290.33, 26.62, -259.11, -119.41, 310.83, 493.61, -428.46, 129.77, -187.8, -137.51, 279.11, -57.95, -146.72, 402.19, 431.8, -99.81, 477.9, -472.04, -387.11, -228.63, 30.23, 481.66, -464.52, -370.93, 32.81, 209.84, 374.79, 333.53, 343.74, 402.3, 195.44, 482.45, -262.21, -249.76, 336.33, 180.19, -7.52, 333.28, 43.4, -97.85, -404.59, -221.78, 20.75, 35.82, -227.73, -404.01, 196.82, -111, -298.68, 295.44, 253.1, -426.18, -254.65, -258.46, -73.13, 223.85, 367.38, 79.99, -145.02, 62.47, 50.16, -141.46, -478, 392.86, 222.05, -200.28, -205.84, -391.74, 214.49, -244.31, 77.35, 1.34, 482.92, -56.48, 166.04, -20.39, 338.95, 331.36, -362.26, 172.79, 228.29, 321.68, 136.28, -138.61, -366.7, -341.27, -241.18, -351.04, -176.95, -147.63, 201.84, 97.42, -150.47, 304.02, 385.96, 40.59, 399.2, -172.3, -171.4, -256.88, 422.94, 72.66, 214.95, 74, -18, 399.86, -149.99, 296.48, 399.56, -253.79, -277.85, 265.09, -138.54, 174.82, 490.57, 386.67, -492.42, -494.5, 382.82, -451.86, -313.08, -320.78, -416.07, 268.87, -450.49, 181.79, -344.28, -125.19, -141.32, -350.37, 272.53, -186.5, -387.6, 121.54, 260.84, -390.98, 204, -437.1, -480.03, -135.69, -155.52, -44.71, -89.89, 235.59, 121.38, 156.09, 259.13, -431.57, -441.44, -225.07, -306.08, 384.01, 8.51, 312.53, 70.58, 143.08, 386.2, -137.02, -36.09, -158.42, -86.38, -284.02, 344.97, -32.91, -119.09, -209.45, 428.34, -405.83, 146.95, -85.56, -59.6, 416.13, -230.29, -475.71, -25.27, -199.18, 416.03, -10.69, -81.44, 106.45, 358.82, 176.5, 265.83, -60.56, 233.62, 96.6, 9.86, 457.85, -219.67, -159.15, -54.35, 19.41, 5.64, 490.53, -30.9, -210.6, -487.83, -340.33, 265.48, -381.26, 108.61, -387.05, -94.4, 339.15, 250.75, 451.58, 337.4, 425.09, 251.41, -362.12, 245.96, 316.69, 136.36, 453.97, 119.94, -379.9, -256.66, -70.16, 26.18, 335.67, -23.27, -469.98, -283.97, 313.98, -182.01, 39.35, -188.25, 248.82, 313.41, 43.94, -303.39, 337.81, -485.39, 187.86, -359.49, -421.4, 411.74, -382.12, -369.85, -215.08, 132.22, 221.73, -130.72, 482.04, 416.54, 111.83, -297.17, -444.87, -196.96, 180.2, -80.22, -200.66, -472.34, -107.32, -95.73, -398.92, -174.9, -17.96, 215.67, -451.94, -300.24, 256.49, -390.01, 115.13, -169.97, 16.22, 471.88, -290.06, 195.14, -253.84, -255.51, 185.07, 402.45, 462.27, -170.52, -371.19, -436.36, -202.44, -385.46, -291.14, -13.92, 404.42, 22.4, 190.42, 384.59, -214.43, -358.78, 369.03, 223.98, 156.65, 322.94, 55.73, -425.07, 46.17, 11.94, -105.81, -250.41, -489.73, 5.21, 358.5, 260.08, -238.91, -322.85, -226.54, 187.61, 448.17, -485.89, 365.18, -327.32, 374.39, -372.21, 450.56, 421.87, -424.68, 459.54, 387.37, 19.07, -181.41, 253.7, 310.82, -205.35, -229.62, -170.71, -67.69, 201.53, 47.12, -12.2, 113.85, 51.2, 221.96, -272.39, 28.54, -423.47, -490.8, 170.22, -268.6, 460.92, -386.15, 45.55, -96.98, 95.14, -92.54, 449.46, -327.17, 58.72, -271.97, 190.93, -456.59, 31.54, -277.62, -106.12, 230.55, -200.82, -272.55, 381.83, 441.33, 376.22, 67.87, -341.93, -242.56, 283.61, -257.58, 272.02, 225.49, 189.81, -283.58, -472.84, -220.82, 295.35, 291.28, 382.35, 369.23, 254.18, 405.26, 82.92, -429.93, 296.03, -277.3, 494.79, 386.49, -406.19, 176.98, 17.14, 327.89, 176.19, -452.12, 246.14, 387.21, 371.49, 221.51, 82.83, 230.18, 185.34, 211.91, 259.75, 347.97, -48.52, -412.57, 285.39, -242.85, 144.35, -119.71, 257.98, -248.95, 121.83, 493.88, 35.33, -131.88, 231.24, -83.21, -223.46, 81.41, 377.13, 360.39, -12.22, 37.84, 256.73, 157.43, -311.86, 222.72, -41.52, 343.95, 361.54, 6.16, 76.15 }, ExpectedResult = 14)]
        public int CheckFindingElementIndexBetweenEqualSums(double[] sourceArray)
        {
            return tWorker.FindElementIndexBetweenEqualSums(sourceArray);
        }

        [TestCase("AsdfeAd", "Assqaasssqs", ExpectedResult = "AsdfeAdqaaq")]
        [TestCase("ABCDEFGhijklmn", "abcdefgHIJKLMN", ExpectedResult = "ABCDEFGhijklmnabcdefgHIJKLMN")]
        [TestCase("a", "a", ExpectedResult = "a")]
        [TestCase("Hell", "o my friEnd", ExpectedResult = "Hello my friEnd")]
        public string CheckStringConcatenation(string firstStr, string secondStr)
        {
            return tWorker.ConcatStrings(firstStr, secondStr);
        }

        [TestCase(100, ExpectedResult = new int[] { 1, 0, 0 })]
        [TestCase(983754210, ExpectedResult = new int[] { 9, 8, 3, 7, 5, 4, 2, 1, 0 })]
        [TestCase(8, ExpectedResult = new int[] { 8 })]
        [TestCase(123, ExpectedResult = new int[] { 1, 2, 3 })]
        public int[] CheckConvertNumberToDigitsArray(int number)
        {
            var type = typeof(TaskWorker);
            var instance = Activator.CreateInstance(type);

            var method = tWorker.GetType()
                .GetMethod("ConvertNumberToDigitsArray", BindingFlags.NonPublic | BindingFlags.Instance);

            return (int[])method.Invoke(instance, new object[] { number });
        }

        [TestCase(new int[] { 1, 0, 0 }, ExpectedResult = 100)]
        [TestCase(new int[] { 9, 8, 3, 7, 5, 4, 2, 1, 0 }, ExpectedResult = 983754210)]
        [TestCase(new int[] { 8 }, ExpectedResult = 8)]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 123)]
        public int CheckConvertDigitsArrayToNumber(int[] digits)
        {
            var type = typeof(TaskWorker);
            var instance = Activator.CreateInstance(type);

            var method = tWorker.GetType()
                .GetMethod("ConvertDigitsArrayToNumber", BindingFlags.NonPublic | BindingFlags.Instance);

            return (int)method.Invoke(instance, new object[] { digits });
        }

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(999, ExpectedResult = -1)]
        [TestCase(10001, ExpectedResult = 10010)]
        [TestCase(987654321, ExpectedResult = -1)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int CheckFindingNextBiggerNumber(int inputNumber)
        {
            double timer;
            return tWorker.FindNextBiggerNumber(inputNumber, out timer);
        }

        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, -69, 70, 15, 17 }, 6, ExpectedResult = new int[] { 6, 68, -69 })]
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, -69, 70, 15, 17 }, 9, ExpectedResult = new int[] { -69 })]
        [TestCase(new int[] { 0, 1, 10, 101 }, 0, ExpectedResult = new int[] { 0, 10, 101 })]
        [TestCase(new int[] { 10, 23, 34, 56, 78 }, 9, ExpectedResult = new int[] { })]
        public int[] CheckDigitFiltering(int[] sourceArray, int digit)
        {
            return tWorker.FilterDigit(sourceArray, digit);
        }

        [MSUnitTest.TestMethod]
        public void CheckDigitFilteringNegativeNumbers()
        {
            MSUnitTest.CollectionAssert.AreEqual(tWorker.FilterDigit(new int[] { -10, 15, -9, -21, 0, 3 }, 1), new int[] { -10, 15, -21 });
            MSUnitTest.CollectionAssert.AreEqual(tWorker.FilterDigit(new int[] { -1, -2, -3, -4, -5, -6, -7, -8, -9, 0 }, 5), new int[] { -5 });
            MSUnitTest.CollectionAssert.AreEqual(tWorker.FilterDigit(new int[] { -10, -11, -111, -1111, 11111 }, 1), new int[] { -10, -11, -111, -1111, 11111 });
            MSUnitTest.CollectionAssert.AreEqual(tWorker.FilterDigit(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, -69, 70, 15, 17 }, 9), new int[] { -69 });
        }

        const string dataDriver = "System.Data.OleDb";
        const string connectionStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=B:\\git\\epam\\epam_04_BasicCoding\\data.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";

        [MSUnitTest.TestMethod]
        [MSUnitTest.DataSource(dataDriver, connectionStr, "Shit1$", MSUnitTest.DataAccessMethod.Sequential)]
        public void CheckDigitFilteringDDT()
        {
            var rowInputArray = TestContext.DataRow["Input array"].ToString();
            var rowInputDigit = TestContext.DataRow["Input digit"].ToString();
            var rowExpected = TestContext.DataRow["Expected Result"].ToString();
            var rowException = TestContext.DataRow["Exception"].ToString();
            var rowComment = TestContext.DataRow["Comment"].ToString();

            var sourceArray = rowInputArray.Split(' ').Select(x => int.Parse(x)).ToArray();
            var digit = int.Parse(rowInputDigit);

            var actualResult = string.Join(" ", tWorker.FilterDigit(sourceArray, digit));
            Assert.AreEqual(rowExpected, actualResult);
        }
    }
}
