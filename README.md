# RandomTest

## 代码逻辑场景
+ 按下任意按键在4个list池中按照指定概率随机一个，然后在此list中随机抽取一个结果。
+ 尝试将代码中的两个random对象seed更换为不同的值，结果恢复正常
+ 尝试更换了一个第三方random库，结果恢复正常
## 问题复现操作步骤
+ 编译运行程序，按下任意按键
+ 重复上述步骤
+ 发现当随机到长度为3的list时，index结果必定为2
