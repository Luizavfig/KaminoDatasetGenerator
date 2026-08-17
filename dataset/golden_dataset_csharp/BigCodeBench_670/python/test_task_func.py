import unittest
class TestCases(unittest.TestCase):
    def test_case_1(self):
        self.assertEqual(task_func('c', {'a': 1, 'b': 2, 'c': 3}), 'c')
    
    def test_case_2(self):
        self.assertEqual(task_func('aabc', {'a': 10, 'b': -5, 'c': 3}), 'aa')
    def test_case_3(self):
        self.assertEqual(task_func('aabc', {'a': 10, 'b': -2, 'c': 3}), 'aabc')
    def test_case_4(self):
        self.assertEqual(task_func('aabc', {'a': 2, 'b': -5, 'c': 3}), 'aa')
    
    def test_case_5(self):
        self.assertEqual(task_func('aabc', {'a': 0, 'b': -1, 'c': 1}), 'c')
