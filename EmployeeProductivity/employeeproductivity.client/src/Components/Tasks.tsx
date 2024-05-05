import React, {useEffect, useRef, useState} from 'react';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import PostList from "./PostList";
import Modal from 'react-modal';
import MyModal from './MyModal';
import axios from 'axios';

const Tasks = () => {
    const [newPosts, setNewPosts] = useState([])
    const [modalIsOpen, setIsOpen] = useState(false);
    const typeOfUser = sessionStorage.getItem('userRole');

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
            });
            const posts = response.data.map((item) => ({
                id: item.id,
                title: item.title,
                date: item.deadline,
                description: item.mainInfo,
                difficulty: Number(item.complexity)+1
            }));
            setNewPosts([...posts]);
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
            <PostList posts={newPosts} nameOfOption={"Задачи"}/>
        </>
    );
};

export default Tasks;