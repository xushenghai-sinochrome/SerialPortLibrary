using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInterfaces
{
    public interface ILMicroscopeInterface: SerialPortInterface
    {
        /*=====================================================================================================================*/
        int                             setMasterEvents                     (                           );
        int                             setZDriveEvents                     (                           );
        int                             setObjectiveEvents                  (                           );
        int                             setTLFieldEvents                    (                           );
        int                             setTLEvents                         (                           );
        int                             setMasterReset                      (                           );
        int                             setMasterDefault                    (                           );
        int                             setMasterConfigMode                 (bool enable                );
        int                             setMasterWaitTimes                  (int  waittimes             );
        int                             setManualOptionStatus               (bool enable                );
        (int, int)                      getMicroscopeInitStatus             (                           );
        (int, int)                      getMasterFirmwareStatus             (                           );
        (int, int)                      getMasterConfigMode                 (                           );
        (int, int)                      getManualOptionStatus               (                           );

        /*=====================================================================================================================*/
        int                             setZDriverManualOptionStatus        (bool enable                );
        int                             setZDriverReset                     (                           );
        int                             setZDriverInit                      (                           );
        int                             setZDriverBreak                     (                           );
        int                             setZDriverAbsPosition               (int value                  );
        int                             setZDriverRelPosition               (int value                  );
        int                             setZDriverConstPosition             (int value                  );
        int                             setZDriverLowerLimit                (int value                  );
        int                             setZDriverFocusLimit                (int value                  );
        int                             setZDriverUpperLimit                (int value                  );
        int                             setZDriverAcceleration              (int value                  );
        int                             setZDriverSpeed                     (int value                  );
        int                             ZDriverMoveToFocusLimit             (                           );
        int                             ZDriverMoveToLowerLimit             (                           );
        int                             ZDriverPositionAsFocus              (                           );
        int                             ZDriverPositionAsLower              (                           );
        int                             ZDriverInitRange                    (                           );
        int                             setZDriverMoveMode                  (bool enable                );
        int                             setZDriverFocusLimitEnable          (bool enable                );
        int                             setZDriverInitMode                  (string value               );
        (int, int, int, int, int)       getZDriverStatus                    (                           );
        (int,           int     )       getZDriverManualOptionStatus        (                           );
        (int,           int     )       getZDriverFirmwareStatus            (                           );
        (int,           int     )       getZDriverAbsPosition               (                           );
        (int,           int     )       getZDriverLowerLimit                (                           );
        (int,           int     )       getZDriverFocusLimit                (                           );
        (int,           int     )       getZDriverAcceleration              (                           );
        (int,           int     )       getZDriverSpeed                     (                           );
        (int,           int     )       getZDriverConvertFactor             (                           );
        (int,           int     )       getZDriverMinAcceleration           (                           );
        (int,           int     )       getZDriverMaxAcceleration           (                           );
        (int,           int     )       getZDriverMoveMode                  (                           );
        (int,           int     )       getZDriverFocusLimitEnable          (                           );
        (int,           int     )       getZDriverMinSpeed                  (                           );
        (int,           int     )       getZDriverMaxSpeed                  (                           );
        (int,           int     )       getZDriverUpperLimit                (                           );
        (int,           string  )       getZDriverInitMode                  (                           );
        /*===============================================物镜操作方法======================================================================*/
        int                             setObjectiveManualOperation         (bool           value       );
        int                             setObjectiveAbsPosition             (int            value       );
        int                             setObjectiveRelPosition             (int            value       );
        int                             setObjectiveOperationMode           (int            value       );
        int                             setObjectiveDRYMode                 (string         value       );
        int                             setObjectiveMethodParameter         (List<int>      value       );
        int                             setObjectivePathoMode               (int            value       );
        int                             setObjectiveDIP                     (                           );
        (int, int, int, int)            getObjectiveStatus                  (                           );
        (int,           int)            getObjectiveManualOperationStatus   (                           );
        (int,           int)            getObjectiveAbsPosition             (                           );
        (int,           int)            getObjectiveOperationStatus         (                           );
        (int,           int)            getObjectiveDryStatus               (                           );
        (int,           int)            getObjectiveMethodParameter         (int level, int parameter   );
        (int,           int)            getObjectiveMinPosition             (                           );
        (int,           int)            getObjectiveMaxPosition             (                           );
        (int,           int)            getObjectivePathoMode               (                           );     
    }
}
