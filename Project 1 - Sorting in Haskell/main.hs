module Main where
import MergeSort
import QuickSort

main = do
  let unsorted = [4, 65, 2, -31, 0, 99, 2, 83, 782, 1]
  
  print "Quick Sorting"
  let quick_sorted = qsort unsorted
  print(quick_sorted)

  print "Merge Sorting"
  let merge_sorted = msort unsorted
  print(merge_sorted)