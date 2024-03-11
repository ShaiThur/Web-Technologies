import { faRightToBracket } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import "../Css/workZone.css"
import {useState} from "react";

const WorkZone = () => {
    const [nameLabel, setNameLabel] = useState('Задания');
    const [activeButton, setActiveButton] = useState('button1');

    const ChangePage = (nameLabel : string, buttonName : string) => {
        setActiveButton(buttonName);
        setNameLabel(nameLabel);
    }

    return (
        <div className='mainViewWork'>
            <div className="workzone">
                <div className="header">
                    <div className="headerContents">
                        <label htmlFor="">Арсений Королёв</label>
                        <button className={'exitIcon'}>
                            <FontAwesomeIcon icon={faRightToBracket} />
                        </button>
                    </div>
                    <label id={'tasks'}>{nameLabel}</label>
                    <div className={'tabs'}>
                        <button className={'tabsButtons'}
                                id={activeButton == 'button1' ? 'activeButton' : ''}
                                onClick={() => ChangePage('Задания', 'button1')}>
                            Задачи
                        </button>
                        <button className={'tabsButtons'}
                                id={activeButton == 'button2' ? 'activeButton' : ''}
                                onClick={() => ChangePage('Предложенные задания', 'button2')}>
                            Предложенные
                        </button>
                        <button className={'tabsButtons'}
                                id={activeButton =='button3' ? 'activeButton' : ''}
                                onClick={() => ChangePage('Статистика', 'button3')}>
                            Статистика
                        </button>
                    </div>
                </div>
                <div className="body">
                    <button>Жми</button>
                </div>
            </div>
        </div>
    );
};

export default WorkZone;