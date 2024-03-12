import { faRightToBracket } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import "../Css/workZone.css"
import {useState} from "react";
import Post from "./Post";
import Tasks from "./Tasks";
import OffersTask from "./OffersTask";
import Statistic from "./Statistic";

const WorkZone = () => {
    const [nameLabel, setNameLabel] = useState('Задания');
    const [activeButton, setActiveButton] = useState('button1');
    const [posts, setPosts] = useState([
        {title: 'Купить пиво', deadLine: '25/04/2024', countStars:2},
        {title: 'Купить селёдочки', deadLine: '25/04/2024', countStars:3},
        {title: 'Сходить нахуй', deadLine: '12/03/2024', countStars:3}
    ])

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
                    {nameLabel == 'Задания' ? <Tasks posts={posts}/> : nameLabel == 'Предложенные задания' ? <OffersTask/> : <Statistic/>}
                </div>
            </div>
        </div>
    );
};

export default WorkZone;