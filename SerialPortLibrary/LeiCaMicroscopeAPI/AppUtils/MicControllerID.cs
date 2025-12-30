using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtils
{
    public class MicControllerID
    {
        // 显微镜事件
        public static int SET_MASTER_EVENT                          = 70003 ; // 设置事件
        public static int SET_Z_DRIVE_EVENT                         = 71003 ; // 参数 0: Z-DRIVE 已启动或停止！*参数 1：已到达或离开下部硬件限位开关！* 参数 2：已到达或离开上部硬件限位开关！* 参数 3：已到达或离开下限阈值！* 参数 4：已到达或离开焦点位置 参数 5：已达到新的 Z 位置！参数6：已设置新的下限阈值！参数 7：已设置新的焦点位置！参数 8：新的 Z_STEP_MODE（粗/细）设置！
        public static int SET_OBJECTIVE_EVENT                       = 76003 ; // 设置物镜事件
        public static int SET_SPOTLIGHT_EVENT                       = 81003 ; // 设置聚光镜顶镜事件
        public static int SET_FIELD_TL_EVENT                        = 83003 ; // 设置孔径光阑事件
        public static int SET_TL_EVENT                              = 84003 ; // 设置光源事件

        // 显微镜控制指令
        public static int SET_MASTER_MANUAL_OPERATION               = 70005 ; // 打开或关闭整个支架的所有电子操作元件的手动操作
        public static int GET_MASTER_MANUAL_OPERATION               = 70006 ; // 返回手动操作是否打开或关闭
        public static int SET_MASTER_RESET                          = 70007 ; // 重置整个支架 主处理器生成软件复位
        public static int GET_MASTER_FIRMWARE_STATUS                = 70008 ; // 固件状态 0 固件正在从引导扇区运行 1 固件正在从程序内存运行
        public static int SET_MASTER_DEFAULT                        = 70018 ; // 显微镜重置为出厂默认设置
        public static int GET_MASTER_CONFIG_MODE                    = 70074 ; // 获取配置模式 0 配置模式关闭 1 配置模式打开
        public static int SET_MASTER_CONFIG_MODE                    = 70075 ; // 设置配置模式 0 配置模式关闭 1 配置模式打开
        public static int GET_MASTER_INIT_STATUS                    = 70080 ; // 获取初始化状态
        public static int SET_MASTER_WAIT_TIMES                     = 70082 ; // 设置等待时间

        // Z轴控制指令
        public static int GET_Z_DRIVER_STATUS                        = 71004; // 参数1：已到达下限硬件开关！参数2：已到达上限硬件开关！参数3：已到达下限阈值！参数 4：焦点位置已到达
        public static int SET_Z_DRIVER_MANUAL_OPERATION              = 71005 ;// 打开或关闭Z轴的手动操作
        public static int GET_Z_DRIVER_MANUAL_OPERATION              = 71006 ;// 返回手动操作是否打开或关闭
        public static int SET_Z_DRIVER_RESET                         = 71007 ;// 复位单元 参数重置为默认值
        public static int GET_Z_DRIVER_FIRMWARE_STATUS               = 71008 ;// 固件状态 0 固件正在从引导扇区运行 1 固件正在从程序内存运行
        public static int SET_Z_DRIVER_INIT                          = 71020 ;// 初始化 Z-DRIVE Z-DRIVE 移动到下方硬件端开关并重置零点
        public static int SET_Z_DRIVER_BREAK                         = 71021 ;// 中止 Z-DRIVE 的当前定位
        public static int SET_Z_DRIVER_ABS_POSITION                  = 71022 ; // 将功能单元定位到以微步（计数）为单位的给定绝对值
        public static int GET_Z_DRIVER_ABS_POSITION                  = 71023 ; // 以微步（计数）为单位读取功能单元的当前位置
        public static int SET_Z_DRIVER_REL_POSITION                  = 71024 ; // 将功能单元定位到以微步（计数）为单位的给定相对位置值
        public static int SET_Z_DRIVER_CONST_POSITION                = 71025 ; // 以恒定速度移动功能单元
        public static int SET_Z_DRIVER_LOWER_LIMIT                   = 71026 ; // 将下限阈值设置为给定的 Z 轴位置
        public static int SET_Z_DRIVER_FOCUS_LIMIT                   = 71027 ; // 将焦点位置设置为指定的 Z 轴位置
        public static int GET_Z_DRIVER_LOWER_LIMIT                   = 71028 ; // 读取当前下限的Z值
        public static int GET_Z_DRIVER_FOCUS_LIMIT                   = 71029 ; // 读取当前焦点位置。
        public static int SET_Z_DRIVER_ACCELERATION                  = 71030 ; // 设置新的加速度参数
        public static int GET_Z_DRIVER_ACCELERATION                  = 71031 ; // 读取加速度参数
        public static int SET_Z_DRIVER_SPEED                         = 71032 ; // 定义Z轴运动的最大速度
        public static int GET_Z_DRIVER_SPEED                         = 71033 ; // 读取当前Z轴运动速度
        public static int Z_DRIVER_MOVE_TO_FOCUS_LIMIT               = 71034 ; // 将 Z 轴驱动器移动到当前焦点位置
        public static int Z_DRIVER_MOVE_TO_LOWER_LIMIT               = 71035 ; // 将 Z 轴驱动移至当前下限
        public static int SET_Z_DRIVER_LOWER_POSITION                = 71037 ; // 将当前 Z 轴位置定义为下限阈值
        public static int SET_Z_DRIVER_FOCUS_POSITION                = 71038 ; // 将当前 Z 轴位置定义为下限阈值
        public static int GET_Z_DRIVER_CONVERT_FACTOR                = 71042 ; // 获取转换因子
        public static int Z_DRIVER_INIT_RANGE                        = 71044 ; // 初始化范围Z
        public static int GET_Z_DRIVER_MIN_ACCELERATION              = 71048 ; // 读取加速度参数
        public static int GET_Z_DRIVER_MAX_ACCELERATION              = 71049 ; // 读取加速度参数
        public static int SET_Z_DRIVER_MOVE_MODE                     = 71050 ; // 将当前Z 驱动运动模式0 = 细步 1 = 粗步 2 = 切换
        public static int GET_Z_DRIVER_MOVE_MODE                     = 71051 ; // 将当前Z 驱动运动模式0 = 细步 1 = 粗步 2 = 切换
        public static int SET_Z_DRIVER_FOCUS_LIMIT_ENABLED           = 71053 ; // 激活焦点限制活动模式
        public static int GET_Z_DRIVER_FOCUS_LIMIT_ENABLED           = 71054 ; // 激活焦点限制活动模式
        public static int SET_Z_DRIVER_UPPER_LIMIT                   = 71055 ; // 上限阈值设置为给定的 Z 位置
        public static int GET_Z_DRIVER_UPPER_LIMIT                   = 71056 ; // 读取上限阈值的当前 Z 值
        public static int GET_Z_DRIVER_MIN_SPEED                     = 71058 ; // 读取速度参数
        public static int GET_Z_DRIVER_MAX_SPEED                     = 71059 ; // 读取速度参数
        public static int SET_Z_DRIVER_INIT_MODE                     = 71065 ; // 设置开机时 Z 轴的初始化模式 - = 没有初始化Z轴 N = 低于 4 毫米或低于软件阈值（默认）Z = 低于软件阈值 如果未设置阈值，则调整零位。
        public static int GET_Z_DRIVER_INIT_MODE                     = 71066 ; // 获取Z轴初始化状态

        public static int GET_OBJECTIVE_STATUS                      = 76004 ; // 获取物镜状态
        public static int SET_OBJECTIVE_MANUAL_OPERATION            = 76005 ; // 打开或关闭Z轴的手动操作
        public static int GET_OBJECTIVE_MANUAL_OPERATION            = 76006 ; // 返回手动操作是否打开或关闭
        public static int SET_OBJECTIVE_ABS_POSITION                = 76022 ; // 设置物镜位置
        public static int GET_OBJECTIVE_ABS_POSITION                = 76023 ; // 获取物镜位置 
        public static int SET_OBJECTIVE_REL_POSITION                = 76024 ; // 物镜相对移动
        public static int SET_OBJECTIVE_OPERATION_MODE              = 76025 ; // 设置物镜操作模式
        public static int GET_OBJECTIVE_OPERATION_MODE              = 76026 ; // 获取物镜操作模式
        public static int SET_OBJECTIVE_DRY_MODE                    = 76027 ; // 设置物镜DRY模式
        public static int GET_OBJECTIVE_DRY_MODE                    = 76028 ; // 获取物镜DRY模式
        public static int SET_OBJECTIVE_METHOD_PARAMETER            = 76032 ; // 设置物镜方法参数
        public static int GET_OBJECTIVE_METHOD_PARAMETER            = 76033 ; // 获取物镜方法参数
        public static int GET_OBJECTIVE_MIN_POSITION                = 76038 ; // 获取最小物镜位置
        public static int GET_OBJECTIVE_MAX_POSITION                = 76039 ; // 获取最大物镜位置
        public static int SET_OBJECTIVE_DIP                         = 76040 ; // 获取DIP
        public static int SET_OBJECTIVE_PATHO_MODE                  = 76046 ; // 设置物镜病理模式 
        public static int GET_OBJECTIVE_PATHO_MODE                  = 76047 ; // 获取物镜病理模式 
    }
}
