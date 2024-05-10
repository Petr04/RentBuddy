# Идея:
Cайт RentBuddy, на котором студенты смогут искать друзей, с которыми им будет комфортно снимать жильё.  
Интерфейс поиска сожителей будет устроен по принципу, который используется во многих приложениях для знакомств, таких как Tinder. В центральной части экрана будет расположена карточка с информацией о человеке, которую можно будет смахнуть вправо, если ты готов делить с этим человеком жильё, и влево в противном случае. Также на сайте планируется каталог недвижимости, который будет пополняться за счёт сотрудничества с собственниками, а также центрами размещения студентов, таких как проектный офис "Платное жильё" от союза студентов УрФУ, и хостелами. Перед поиском сожителей необходимо будет отметить варианты жилья, куда вы хотели бы заселиться.

# Список примерного функционала:
1. Вход, регистрация.
2. Создание, редактирование, удаление, страница просмотра профиля студента.
3. Создание, редактирование, удаление, страница просмотра объекта недвижимости
4. Поиск объектов недвижимости
5. Метчинг с потенциальными сожителями (как в Tinder)
6. Создание, редактирование, удаление, страница просмотра профиля собственника/агентства. На странице просмотра должны быть имя, фамилия, аватар, список объектов недвижимости этого собственника или агентства.  

# Грейды функционала 
| Пункт в ТЗ                                         | Путь в проекте |
| -------------------------------------------------- | -------------- |
| **0 - 40**                                                          |
| 3 - 4 реактивные формы + форма авторизации + кэш   |                |
| 2 - 3 функциональных модуля                        |                |
| lazy-loading функциональных модулей (роутинг)      |                |
| Простое внедрение зависимостей                     |        +       |
| Использование свойств с декораторами @Input @Output|        +       |
| Базовое использование RxJS                         |        +       |
| Реализован основной функционал приложения          |                |
| **40 - 60**                                                         |
| Использование паттерна "Фабрика"                   |                |
| Reusable компоненты                                |        +       |
| Передача параметров в роуте                        |                |
| Реализация Route Guards                            |                |
| Строгая типизация и отсутствие any                 |        +       |
| 1-2 кастомная атрибутивная директива               |                |
| 1-2 кастомных пайпы                                |                |
| Использование свойств с декораторами @ViewChild и @ViewChildren |                |
| Запросы на сервер                                  |        +       |
| Использование общего code-style (настройка eslint) |        +       |
| **60 - 80**                                                         |
| MVVM                                               |                |
| Продвинутое использование DI (использование токенов, useFactory) |                |
| DRY                                                |                |
| Хлебные крошки                                     |                |
| Кастомная структурная директива                    |                |
| Обработка ошибок. Global error handler             |                |
| Динамический рендер                                |                |
| Использование @HostListener                        |                |
| **80 - 100**                                                         |
| SOLID                                              |                |
| Глобальный сервис событий                          |                |
| Адаптивность                                       |                |
| Скелетоны                                          |                |
| Angular animations                                 |                |


# Состав участников:
* Султанов Михаил Евгеньевич
* Буцких Андрей Сергеевич
* Волчихин Артем Алексеевич
