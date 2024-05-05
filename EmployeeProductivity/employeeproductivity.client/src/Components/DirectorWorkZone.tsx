import { faRightToBracket } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { useState } from 'react';
import Tasks from './Tasks';
import Employees from './Employees';
import StatisticForOne from './StatisticForOne';
import { useNavigate } from 'react-router-dom';

const DirectorWorkZone = () => {
    const [nameLabel, setNameLabel] = useState('Задачи');
    const [activeButton, setActiveButton] = useState('button1');
    const navigate = useNavigate();

    const ChangePage = (nameLabel : string, buttonName : string) => {
        setActiveButton(buttonName);
        setNameLabel(nameLabel);
    }

    const Exit = () => {
        navigate("/");
    }
    
    return (
        <>
            <div className="workzone">
                    <div className="header">
                        <div className="headerContents">
                            <button className={'exitIcon'} onClick={() => Exit()}>
                                <FontAwesomeIcon icon={faRightToBracket} />
                            </button>
                        </div>
                        <label id={'tasks'}>{nameLabel}</label>
                        <div className={'tabs'}>
                            <button className={'tabsButtons'}
                                    id={activeButton == 'button1' ? 'activeButton' : ''}
                                    onClick={() => ChangePage('Задачи', 'button1')}>
                                Задачи
                            </button>
                            <button className={'tabsButtons'}
                                    id={activeButton == 'button2' ? 'activeButton' : ''}
                                    onClick={() => ChangePage('Работники', 'button2')}>
                                Работники
                            </button>
                            <button className={'tabsButtons'}
                                    id={activeButton =='button3' ? 'activeButton' : ''}
                                    onClick={() => ChangePage('Статистика', 'button3')}>
                                Статистика
                            </button>
                        </div>
                    </div>


                <div className="body">
                    {nameLabel == 'Задачи' ? <Tasks/> : nameLabel == 'Работники' ? <Employees/> : <StatisticForOne/>}
                </div>
            </div>
        </>
    );
};

export default DirectorWorkZone;