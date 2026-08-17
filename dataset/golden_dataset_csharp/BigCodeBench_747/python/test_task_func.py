import unittest
class TestCases(unittest.TestCase):
    def test_1(self):
        count, sqrt_sum = task_func('1,2,3.5,abc,4,5.6')
        self.assertEqual(count, 5)
        self.assertAlmostEqual(sqrt_sum, sum(math.sqrt(x) for x in [1, 2, 3.5, 4, 5.6]))
    def test_2(self):
        count, sqrt_sum = task_func('a,b,c,10,20.5')
        self.assertEqual(count, 2)
        self.assertAlmostEqual(sqrt_sum, sum(math.sqrt(x) for x in [10, 20.5]))
    def test_3(self):
        count, sqrt_sum = task_func('1.1,2.2,3.3')
        self.assertEqual(count, 3)
        self.assertAlmostEqual(sqrt_sum, sum(math.sqrt(x) for x in [1.1, 2.2, 3.3]))
    def test_4(self):
        count, sqrt_sum = task_func('')
        self.assertEqual(count, 0)
        self.assertEqual(sqrt_sum, 0.0)
    def test_5(self):
        count, sqrt_sum = task_func('apple,banana,3.14,15,grape,1001')
        self.assertEqual(count, 3)
        self.assertAlmostEqual(sqrt_sum, sum(math.sqrt(x) for x in [3.14, 15, 1001]))
