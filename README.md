# GraduationProject

################### 요구 프로그램 ###################
1. 키움 API
2. Mysql

3. Anaconda 32비트 (키움 API가 64bit를 지원 안합니다)
  pyqt5, pandas, dart_fss, pykrx, pymysql, sqlalchemy 패키지를 먼저 설치해야합니다.
################### 사용법 ###################

1. C# 프로젝트 실행
2. 설정에서 모든 내용을 채워야 APICollector 및 DartCollector를 실행가능합니다.
    + SettingsInfo.bin로 저장되므로 처음에만 설정하면 됩니다.
    + 인터프리터 경로 : 32bit Anaconda의 python.exe 경로
    + APICollector 경로 : 파이썬 프로젝트의 APICollector.py
    + DartCollector 경로 : 파이썬 프로젝트의 DartCollector.py
    + 권장 Requests Interval : 0.4
    + 권장 Max Requsts Count : 1000
    + Dart API Key : 085990c5ee309d660c0e658abaeb455e7454eecb (외부로 유출하시면 안됩니다.)
    + DB는 생성하신 mysql 계정정보 및 주소정보를 입력하시면 됩니다.
