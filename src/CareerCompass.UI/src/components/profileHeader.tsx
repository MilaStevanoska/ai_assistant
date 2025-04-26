import React from 'react';

interface ProfileHeaderProps {
  name: string;
  major: string;
  profileImage: string;
}

const ProfileHeader: React.FC<ProfileHeaderProps> = ({ name, major, profileImage }) => {
  return (
    <div className="flex flex-col items-center  rounded-lg p-4 h-full">
      <div className="w-32 h-32 rounded-full overflow-hidden mb-4">
        <img src={profileImage} alt="Profile" className="w-full h-full object-cover bg-blue-500" />
      </div>
      <div className="text-center">
        <h2 className="text-3xl font-bold">{name}</h2>
        <p className="text-gray-600 text-2xl">{major}</p>
      </div>
    </div>
  );
};

export default ProfileHeader;