﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pi015.Intro.PDll
{
  /*
   * Предметная область: механические часы
   * Часы
   *    + внутренний механизм;
   *        + стрелка[] 
   *        (часовая, минутная, секундная, будильник)
   *          - поворот (градусах);
   *          - толщина, длина, цвет;
   *          - четность поворота;
   *          - скорость (градусы/такт)
   *    * получить информацию о стрелках;
   *    * получить и интерпретацию стрелок в виде строки (текущее время)
   *       1. trunc([стрелку часовую].[поворот] / (360 / 12)) 
   *        + ([стрелку часовую].[четность поворота] % 2 == 0 
   *            ? 12 
   *            : 0)      
   *       2. trunc([стрелку минутную].[поворот] / (360 / 60)) ,
   *       3. trunc([стрелку секундная].[поворот] / (360 / 60)) ,
   *    * установить время (
   *        количество часов, количество минут, количество секунд
   *      )
   *      
   *      [стрелку часовую].[четность поворота] = 
   *        количество часов >= 12
   *      [стрелку часовую].[поворот] = 
   *        (количество часов % 12) * (360/12)
   *          + [количество минут] * (360/12 / 60)
   *          + [количество секунд] * (360/12 / 60 / 60)
   *      [стрелку минутная].[поворот] = 
   *          [количество минут] * (360/60)
   *          + [количество секунд] * (360/60 / 60)
   *      [стрелку секундная].[поворот] = 
   *          [количество секунд] * (360/60)
   *        
   *    * установить будильник
   *    (
   *        количество часов, количество минут, количество секунд
   *    )
   *      [стрелку будильника].[четность поворота] = 
   *        количество часов >= 12
   *      [стрелку будильника].[поворот] = 
   *        (количество часов % 12) * (360/12)
   *          + [количество минут] * (360/12 / 60)
   *          + [количество секунд] * (360/12 / 60 / 60)
   *
   * *    * проверить будильник;
   *      [стрелку будильника].[поворот] = 
   *      [стрелку часов].[поворот]
   *      
   * Абстагируемся от:   
   *    - "текущее время"
   *    - циферблат;
   *    - корпус.
   *    
   * 
   * Предметная область: 
   *    Учебник в библиотеке
   * 
   * Карточка книги 
   *  + название
   *  + автор
   *  + год издания
   *  + количество страниц
   *  + издательство
   *  + размер
   *  + ISBN
   *  + тираж
   *  - главы
   *  - оглавление
   *  - приложения
   *  - закладки
   *  - вес
   *  - введение
   * 
   * Экземпляр учебника:
   *  - инвентарный номер
   *  - карточка книги
   *  - дата изменения статуса
   *  - статус (состояние: списан, выдан, доступен)
   *  
   * Карточка экземпляра:
   *  - экземпляр учебника;
   *  - информация о выдаче[]
   *  
   * информация о выдаче:
   *  - дата
   *  - кто взял
   *  - дата возврата
   *  - кто выдал
   */

  class Clock
  {






  }
}
