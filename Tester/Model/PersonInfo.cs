using System.ComponentModel;
using Tester.Model;

namespace Tester
{
    class PersonInfo
    {
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Самооценка")]
        public SelfTest Self { get; set; }
        [DisplayName("Тревожность")]
        public AnxietyTest Anxiety { get; set; }
        [DisplayName("Мотивация избегания неудач")]
        public FailrueTest Failrue { get; set; }
        [DisplayName("Личностная адаптивность")]
        public PersonalTest Personal { get; set; }
        [DisplayName("Мотивация к успеху")]
        public MotivationTest Motivation { get; set; }
        [DisplayName("Кеттел")]
        public KettelTest Kettel { get; set; }
        

        public PersonInfo()
        {
            Anxiety = new AnxietyTest();
            Failrue = new FailrueTest();
            Personal = new PersonalTest();
            Motivation = new MotivationTest();
            Kettel = new KettelTest();
            Self = new SelfTest();
        }
    }
}
