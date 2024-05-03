import { faRightToBracket } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import "../Css/workZone.css"
import React, {useEffect, useState} from "react";
import Post from "./Post";
import Tasks from "./Tasks";
import OffersTask from "./OffersTask";
import StatisticForOne from "./StatisticForOne";
import {Link, useNavigate, useParams} from "react-router-dom";
import Employees from "./Employees";
import AllStatistic from "./AllStatistic";
import ErrorPage from "./ErrorPage";
import tasks from "./Tasks";
import axios from 'axios';

const WorkZone = () => {
    const [nameLabel, setNameLabel] = useState('Задачи');
    const [activeButton, setActiveButton] = useState('button1');

    const navigate = useNavigate();
    const typeOfUser = 'director';

    useEffect(() => {
        GetUserInf();
    }, [])

    const GetUserInf_GetRequest = async() =>{
        console.log('GetUserInf_GetRequest')
        const email = sessionStorage.getItem('userEmail');
        const accessToken = localStorage.getItem('accessToken')
        console.log('Token ', accessToken)
        console.log('Email', email)

        const response = await axios.request({
            url: "http://localhost:5000/api/User/GetUserInformation",
            method: 'get',
            withCredentials: true,
            headers: {
                userLogin: email,
                Authorization: `Bearer ${accessToken}`
            }
        })
        console.log('Response is ',response)
    }

    const GetUserInf = () => {
        console.log('GetUserInf')
        GetUserInf_GetRequest();
    }

    const ChangePage = (nameLabel : string, buttonName : string) => {
        setActiveButton(buttonName);
        setNameLabel(nameLabel);
    }

    const Exit = () => {
        navigate("/");
    }

    return (
        <div className='mainViewWork'>
            {typeOfUser == "director" ?  <div className="workzone">
                    <div className="header">
                        <div className="headerContents">
                            <label htmlFor="">{'ars'}</label>
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
                </div>:
                (<div className="workzone">
                <div className="header">
                    <div className="headerContents">
                        <label htmlFor="">{name}</label>
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
                    {nameLabel == 'Задачи' ? <Tasks/> : nameLabel == 'Предложенные задания' ? <OffersTask/> : <StatisticForOne/>}
                </div>
            </div>)}
        </div>
    );
};

export default WorkZone;