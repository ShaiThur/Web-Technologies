import React, {useEffect, useRef, useState} from 'react';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import PostList from "./PostList";
import Modal from 'react-modal';
import MyModal from './MyModal';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const Tasks = () => {
    const [newPosts, setNewPosts] = useState([])
    const [modalIsOpen, setIsOpen] = useState(false);
    const [countOfTasksPage, setCountOfTasksPage] = useState([]);
    const [indexActuallyOfPage, setIndexActuallyOfPage] = useState(1);
    const typeOfUser = sessionStorage.getItem('userRole');
    const navigate = useNavigate();

    const RefreshToken = async() =>{
        const email = sessionStorage.getItem('userEmail')
        const response = await axios.request({
            method: 'post',
            url: '/api/User/RefreshUserToken',
            withCredentials: true,
            headers: {
                login: email,
            }
        })
        localStorage.setItem('accessToken', response.data.accessToken)
    }


    const SetActivePage = () =>{

    }
    

    useEffect(() => {
        const getUsersTasks = async() => {
            const departmentId = sessionStorage.getItem('userDepartment');
            const accessToken = localStorage.getItem('accessToken')
            const response = await axios.request({
                url: "api/Job/GetAllJobsInDepartment",
                method: 'get',
                withCredentials: true,
                headers: {
                    departmentId: departmentId,
                    Authorization: `Bearer ${accessToken}`,
                },
            }).catch((error) => {
                if (error.response.status === 401) {
                    RefreshToken().then(() => {
                        getUsersTasks().then((status) => {
                            console.log(status);
                        }).catch(() => {
                            console.log('Cant add new post')
                        });
                    }).catch(() => {
                        navigate(`/form`);
                    });
                } else {
                    alert('Cant add new post');
                }
            });;
            const posts = response.data.map((item) => ({
                id: item.id,
                title: item.title,
                date: item.deadline.split('T')[0],
                description: item.mainInfo,
                difficulty: Number(item.complexity)+1
            }));
            setNewPosts([...posts]);
            const countPages = posts.length / 7;
            let pages = [];
            for(let i=0; i< countPages+1; i++){
                pages.push(i+1);
            }
            setCountOfTasksPage([...pages]);
        }
        getUsersTasks();
    }, [])

    const customStyles = {
        content: {
            top: '50%',
            left: '50%',
            right: 'auto',
            bottom: 'auto',
            marginRight: '-50%',
            transform: 'translate(-50%, -50%)',
        },
    };

    function openModal() {
        setIsOpen(true);
    }
    
    function closeModal() {
        setIsOpen(false);
    }

    return (
        <>
            {typeOfUser == 'Director' ? <div className="plusTask" onClick={() => openModal()}>
                <FontAwesomeIcon icon={faPlus} />
            </div> : ""}
            <Modal
            isOpen={modalIsOpen}
            onRequestClose={closeModal}
            style={customStyles}
            contentLabel="Example Modal"
            ariaHideApp={false}
            >
                <MyModal setNewPost={setNewPosts} posts={newPosts}/>
            </Modal>
            <div className="postlist">
                <PostList posts={newPosts} nameOfOption={"Задачи"}/>
            </div>

            <div className='wrapper'>
                {countOfTasksPage.map(index => 
                    <span key={index} className='wrapperItem' id={index == indexActuallyOfPage ? 'activePage' : ''} onClick={() => setIndexActuallyOfPage(index)}>{index}</span>
                )}
            </div>
        </>
    );
};

export default Tasks;